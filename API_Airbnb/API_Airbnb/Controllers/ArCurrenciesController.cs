using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.CurrenciesRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Airbnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArCurrenciesController : ControllerBase
    {
        private readonly ICurrenciesRepository _currenciesRepository;
        private readonly IMapper _mapper;

        public ArCurrenciesController(ICurrenciesRepository currenciesRepository, IMapper mapper)
        {
            _currenciesRepository = currenciesRepository;
            _mapper = mapper;
        }

        // GET: api/ArRoomTypes
        [HttpGet]
        public ActionResult<IEnumerable<ArCurrenciesReadDTO>> GetArCurrencies()
        {
            var list = _currenciesRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<ArCurrenciesReadDTO>>(list));
        }

        // GET: api/ArRoomTypes/5
        [HttpGet("{id}")]
        public ActionResult<ArCurrenciesReadDTO> GetArCurrencies(int id)
        {
            var currencies = _currenciesRepository.GetById(id);
            if (currencies is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (currencies.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<ArCurrenciesReadDTO>(currencies));
        }

        // PUT: api/ArRoomTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "admin")]
        public ActionResult PutArCurrencies(int id, ArCurrenciesWriteDTO arCurrenciesWriteDTO)
        {
            var currenciesEdit = _currenciesRepository.GetById(id);
            if (currenciesEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (currenciesEdit.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            _mapper.Map(arCurrenciesWriteDTO, currenciesEdit);
            currenciesEdit.Modified = DateTime.Now;
            _currenciesRepository.Update(currenciesEdit);
            _currenciesRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Message = "Currencies Updated" });
        }

        // POST: api/ArRoomTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult<ArCurrencies> PostArRoomType(ArCurrenciesWriteDTO arCurrenciesWriteDTO)
        {
            var count = _currenciesRepository.GetAll().Count;
            var id = count + 1;
            var currencies = _mapper.Map<ArCurrencies>(arCurrenciesWriteDTO);
            currencies.Modified = DateTime.Now;
            currencies.Created = DateTime.Now;
            currencies.Id = id;
            currencies.Status = true;
            _currenciesRepository.Add(currencies);
            _currenciesRepository.SaveChanges();

            return CreatedAtAction("GetArCurrencies", new { id = id }, _mapper.Map<ArCurrenciesReadDTO>(currencies));
        }


        // DELETE: api/ArRoomTypes/5
        [HttpPut("Delete/{id}")]
        [Authorize(Policy = "admin")]
        public ActionResult DeleteArCurrencies(int id)
        {
            var currenciesEdit = _currenciesRepository.GetById(id);
            if (currenciesEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            currenciesEdit.Status = false;
            currenciesEdit.Modified = DateTime.Now;
            _currenciesRepository.Update(currenciesEdit);
            _currenciesRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Massage = "Currencies Deleted" });
        }

        //[HttpPost]
        //[Route("UploadImg")]
        //public ActionResult Upload()
        //{
        //    if (Request.ContentType is null || !Request.ContentType.Contains("multipart/form-data"))
        //    {
        //        return BadRequest(new { Err = "Wrong content type" });
        //    }

        //    var filesFromClient = Request.Form.Files;
        //    if (!filesFromClient.Any())
        //    {
        //        return BadRequest(new { Err = "No file found" });
        //    }

        //    var file = filesFromClient[0];

        //    var allowedExtensions = new string[] { ".jpg", ".svg", ".png" };
        //    if (!allowedExtensions.Any(ext => file.FileName.EndsWith(ext, StringComparison.InvariantCultureIgnoreCase)))
        //    {
        //        return BadRequest(new { Err = "Not valid extension" });
        //    }

        //    if (file.Length > 1_000_000)
        //    {
        //        return BadRequest(new { Err = "Max size exceeded" });
        //    }

        //    if (file.Length <= 0)
        //    {
        //        return BadRequest(new { Err = "Empty file" });
        //    }

        //    var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        //    var fullFilePath = Directory.GetCurrentDirectory() + @"\Assets\Images\" + fileName;

        //    using (var stream = new FileStream(fullFilePath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }

        //    var url = $"{Request.Scheme}://{Request.Host}/Assets/Images/{fileName}";

        //    return Ok(new { Url = url });
        //}
    }
}
