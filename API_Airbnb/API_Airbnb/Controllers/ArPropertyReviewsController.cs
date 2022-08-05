using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.PropertyReviewsRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Airbnb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArPropertyReviewsController : ControllerBase
    {
        private readonly IPropertyReviewsRepository _propRevRepository;
        private readonly IMapper _mapper;

        public ArPropertyReviewsController(IPropertyReviewsRepository propRevRepository, IMapper mapper)
        {
            _propRevRepository = propRevRepository;
            _mapper = mapper;
        }
        [Route("Delete/{Id}")]
        [HttpPut]
        [Authorize]
        public ActionResult Delete(int Id)
        {
            var propertyRevEdit = _propRevRepository.GetById(Id);
            if (propertyRevEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == propertyRevEdit.ReviewByUser || User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                propertyRevEdit.Status = false;
                propertyRevEdit.Modified = DateTime.Now;
                _propRevRepository.Update(propertyRevEdit);
                _propRevRepository.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { Message = "Property Review Deleted" });
            }
            else
            {
                return NotFound(new { Message = "You Can't Delete This Review" });
            }

        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var propertyRev = _propRevRepository.GetById(Id);
            if (propertyRev is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (propertyRev.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<PropertyReviewsReadDTO>(propertyRev));
        }
        [HttpGet]
        [Route("GetByPropertyId/{Id}")]
        public ActionResult GetByPropertyId(int Id)
        {
            var propertyRev = _propRevRepository.GetByPropertyId(Id);
            if (propertyRev is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<List<PropertyReviewsReadDTO>>(propertyRev));
        }
        [HttpGet]
        [Route("GetByBookingId/{Id}")]
        public ActionResult GetByBookingId(int Id)
        {
            var propertyRev = _propRevRepository.GetByBookingId(Id);
            if (propertyRev is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<List<PropertyReviewsReadDTO>>(propertyRev));
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddPropertyReview(PropertyReviewsDTO propertyRevDTO)
        {
            var count = _propRevRepository.GetAll().Count;
            var id = count + 1;
            var propertyRev = _mapper.Map<ArPropertyReviews>(propertyRevDTO);
            propertyRev.Modified = DateTime.Now;
            propertyRev.Created = DateTime.Now;
            propertyRev.Id = id;
            propertyRev.Status = true;
            propertyRev.ReviewByUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _propRevRepository.Add(propertyRev);
            _propRevRepository.SaveChanges();
            return CreatedAtAction(actionName: nameof(GetById), routeValues: new { id = id }, _mapper.Map<PropertyReviewsReadDTO>(propertyRev));
        }
        [Route("Update/{Id}")]
        [HttpPut]
        [Authorize]
        public ActionResult Update(int Id, PropertyReviewsDTO propertyRevDTO)
        {
            var propertyEdit = _propRevRepository.GetById(Id);
            if (propertyEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (propertyEdit.ReviewByUser != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return BadRequest(new { Message = "You Can't Edit This Review As It Wasn't Added By You" });
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == propertyEdit.ReviewByUser || User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                _mapper.Map(propertyRevDTO, propertyEdit);
                propertyEdit.Modified = DateTime.Now;
                _propRevRepository.Update(propertyEdit);
                _propRevRepository.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { Message = "Property Review Updated" });
            }
            else
            {
                return NotFound(new { Message = "You Can't Update This Review" });
            }

        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var propertyRevsList = _propRevRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<PropertyReviewsReadDTO>>(propertyRevsList));
        }
    }
}
