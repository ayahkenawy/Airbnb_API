using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.DisputesRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Airbnb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArDisputesController : ControllerBase
    {
        private readonly IDisputesRepository _disputesRepository;
        private readonly IMapper _mapper;

        public ArDisputesController(IDisputesRepository disputesRepository, IMapper mapper)
        {
            _disputesRepository = disputesRepository;
            _mapper = mapper;
        }
        [Route("Delete/{Id}")]
        [HttpPut]
        public ActionResult Delete(int Id)
        {
            var disputesEdit = _disputesRepository.GetById(Id);
            if (disputesEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == disputesEdit.UserId || User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                disputesEdit.Status = false;
                disputesEdit.Modified = DateTime.Now;
                _disputesRepository.Update(disputesEdit);
                _disputesRepository.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { Message = "Disputes Deleted" });

            }
            else { return NotFound(new { Message = "You Can't Delete This Dispute" }); }

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var dispute = _disputesRepository.GetById(Id);
            if (dispute is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (dispute.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<DisputeReadDTO>(dispute));
        }
        [HttpGet]
        [Route("GetByBookingId/{Id}")]
        public ActionResult GetByBookingId(int Id)
        {
            var disputes = _disputesRepository.GetByBookingId(Id);
            if (disputes is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<List<DisputeReadDTO>>(disputes));
        }
        [HttpGet]
        [Route("GetByPropertyId/{Id}")]
        public ActionResult GetByPropertyId(int Id)
        {
            var disputes = _disputesRepository.GetByPropertyId(Id);
            if (disputes is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<List<DisputeReadDTO>>(disputes));
        }
        [HttpPost]
        public ActionResult AddDispute(DisputeDTO disputeDTO)
        {
            var count = _disputesRepository.GetAll().Count;
            var id = count + 1;
            var Dispute = _mapper.Map<ArDisputes>(disputeDTO);
            Dispute.Modified = DateTime.Now;
            Dispute.Created = DateTime.Now;
            Dispute.Id = id;
            Dispute.Status = true;
            Dispute.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _disputesRepository.Add(Dispute);
            _disputesRepository.SaveChanges();
            return CreatedAtAction(actionName: nameof(GetById), routeValues: new { id = id }, _mapper.Map<DisputeReadDTO>(Dispute));
        }
        [Route("Update/{Id}")]
        [HttpPut]
        public ActionResult Update(int Id, DisputeDTO disputeDTO)
        {
            var disputeEdit = _disputesRepository.GetById(Id);
            if (disputeEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == disputeEdit.UserId || User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                _mapper.Map(disputeDTO, disputeEdit);
                disputeEdit.Modified = DateTime.Now;
                _disputesRepository.Update(disputeEdit);
                _disputesRepository.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { Message = "Dispute Updated" });
            }
            else { return NotFound(new { Message = "You Can't Update This Dispute" }); }

        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var disputesList = _disputesRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<DisputeReadDTO>>(disputesList));
        }
    }
}
