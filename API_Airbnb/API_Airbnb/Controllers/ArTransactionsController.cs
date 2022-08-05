using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Airbnb.Data.DTOs;
using AutoMapper;
using API_Airbnb.Data.Repositories.TransactionsRepository;
using API_Airbnb.Data.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace API_Airbnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArTransactionsController : ControllerBase
    {

        public readonly ITransactionsRepository _transactionsRepository;
        public readonly IMapper _mapper;
        public ArTransactionsController(ITransactionsRepository transactionsRepository, IMapper mapper)
        {
            _transactionsRepository = transactionsRepository;
            _mapper = mapper;

        }

        // GET: api/ArTransactions
        [HttpGet]
        [Authorize(Policy = "admin")]
        public ActionResult<IEnumerable<TransactionsReadDTO>> GetArTransactions()
        {

            var listFromDb = _transactionsRepository.GetAll().Where(c => c.Status == true); ;
            return _mapper.Map<List<TransactionsReadDTO>>(listFromDb);

        }

        // GET: api/ArTransactions/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<TransactionsReadDTO> GetArTransactions(int id)
        {
            var transactions = _transactionsRepository.GetById(id);
            if (transactions is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (transactions.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return _mapper.Map<TransactionsReadDTO>(transactions);

        }


        // PUT: api/ArTransactions/5
        [HttpPut("{id}")]
        [Authorize(Policy ="admin")]
        public IActionResult PutArTransactions(int id, TransactionsWriteDTO arTransactions)
        {
            
            var TransactionsToEdit = _transactionsRepository.GetById(id);
            if (TransactionsToEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            _mapper.Map(arTransactions, TransactionsToEdit);
            TransactionsToEdit.Modified = DateTime.Now;
            _transactionsRepository.Update(TransactionsToEdit);
            _transactionsRepository.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, new { Message = "Transaction Updated" });
        }

        // POST: api/ArTransactions
        [Authorize]
        [HttpPost]
        public ActionResult<ArTransactions> PostArTransactions(TransactionsWriteDTO arTransactions)
        {

            var count = _transactionsRepository.GetAll().Count;
            var id = count + 1;
            var transactions = _mapper.Map<ArTransactions>(arTransactions);
            transactions.Modified = DateTime.Now;
            transactions.Created = DateTime.Now;
            transactions.Id = id;
            transactions.Status = true;
            _transactionsRepository.Add(transactions);
            _transactionsRepository.SaveChanges();
            return CreatedAtAction(actionName: nameof(GetArTransactions), routeValues: new { id = id }, _mapper.Map<TransactionsReadDTO>(transactions));
        }

        // DELETE: api/ArTransactions/5
        [HttpPut()]
        [Authorize(Policy = "admin")]
        [Route("Delete/{id}")]
        public IActionResult DeleteArTransactions(int id)
        {
            var transactionsEdit = _transactionsRepository.GetById(id);
            if (transactionsEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
                transactionsEdit.Status = false;
                transactionsEdit.Modified = DateTime.Now;
                _transactionsRepository.Update(transactionsEdit);
                _transactionsRepository.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { Message = "transactions Deleted" });
           
        }

    }










}
