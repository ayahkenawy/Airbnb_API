using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.PropertyRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Airbnb.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ArPropertiesController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public ArPropertiesController(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }
        [Route("Delete/{Id}")]
        [HttpPut]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult Delete(int Id)
        {
            var propertyEdit = _propertyRepository.GetById(Id);
            if (propertyEdit is null)
            {
                return NotFound(new {Message="Not Found"});
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == propertyEdit.UserId || User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                propertyEdit.Status = false;
                propertyEdit.Modified = DateTime.Now;
                _propertyRepository.Update(propertyEdit);
                _propertyRepository.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { Message = "Property Deleted" });
            }
            else
            {
                return NotFound(new { Message = "You Can't Delete This Property" });
            }
        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var property = _propertyRepository.GetById(Id);
            if (property is null)
            {
                return NotFound(new {Message="Not Found"});
            }
            if (property.Status == false)
            {
                return NotFound(new {Message="Not Found"});
            }
            return Ok(_mapper.Map<PropertyReadDTO>(property));
        }
        [HttpPost]
        //[Authorize(Policy = "adminAndhost")]
        public ActionResult AddProperty(PropertyDTO propertyDTO)
        {
            var count = _propertyRepository.GetAll().Count;
            var id = count + 4;
            var property = _mapper.Map<ArProperties>(propertyDTO);
            property.Modified = DateTime.Now;
            property.Created = DateTime.Now;
            property.Id = id;
            property.Status = true;
            property.UserId=  User.FindFirstValue(ClaimTypes.NameIdentifier);
            _propertyRepository.Add(property);
            _propertyRepository.SaveChanges();
            var propertyData = _propertyRepository.GetWithAllDataByID(property.Id);
            return CreatedAtAction(actionName: nameof(GetWithAllData), routeValues: new { id = property.Id }, _mapper.Map<PropertyChildDTO>(propertyData));
        }
        [Route("Update/{Id}")]
        [HttpPut]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult Update(int Id, PropertyDTO propertyDTO)
        {
            var propertyEdit = _propertyRepository.GetById(Id);
            if (propertyEdit is null)
            {
                return NotFound(new {Message="Not Found"});
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == propertyEdit.UserId || User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                _mapper.Map(propertyDTO, propertyEdit);
                propertyEdit.Modified = DateTime.Now;
                _propertyRepository.Update(propertyEdit);
                _propertyRepository.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { Message = "Property Updated" });
            }
            else
            {
                return NotFound(new { Message = "You Can't Update This Property" });
            }
     
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var propertiesList = _propertyRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<PropertyReadDTO>>(propertiesList));
        }
        [HttpGet]
        [Route("GetWithAllData")]
        public ActionResult GetWithAllData()
        {
            var propertiesList = _propertyRepository.GetWithAllData();
            return Ok(_mapper.Map<List<PropertyChildDTO>>(propertiesList));
        }
        [HttpGet]
        [Route("GetWithAllData/{Id}")]
        public ActionResult GetWithAllData(int Id)
        {
            var property= _propertyRepository.GetWithAllDataByID(Id);
            return Ok(_mapper.Map<PropertyChildDTO>(property));
        }
        [HttpGet]
        [Route("GetWithByHostId")]
        public ActionResult GetWithByHostId()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var property = _propertyRepository.GetWithByHostId(currentUserId);
            return Ok(_mapper.Map<List<PropertyChildDTO>>(property));
        }
        [Authorize(Policy = "adminAndhost")]
        [HttpPost]
        [Route("UploadImg")]
        public ActionResult Upload()
        {
            if (Request.ContentType is null || !Request.ContentType.Contains("multipart/form-data"))
            {
                return BadRequest(new { Err = "Wrong content type" });
            }

            var filesFromClient = Request.Form.Files;
            if (!filesFromClient.Any())
            {
                return BadRequest(new { Err = "No file found" });
            }

            var file = filesFromClient[0];

            var allowedExtensions = new string[] { ".jpg", ".svg", ".png" };
            if (!allowedExtensions.Any(ext => file.FileName.EndsWith(ext, StringComparison.InvariantCultureIgnoreCase)))
            {
                return BadRequest(new { Err = "Not valid extension" });
            }

            if (file.Length > 1_000_000)
            {
                return BadRequest(new { Err = "Max size exceeded" });
            }

            if (file.Length <= 0)
            {
                return BadRequest(new { Err = "Empty file" });
            }

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var fullFilePath = Directory.GetCurrentDirectory() + @"\Assets\Images\" + fileName;

            using (var stream = new FileStream(fullFilePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var url = $"{Request.Scheme}://{Request.Host}/Assets/Images/{fileName}";

            return Ok(new { Url = url });
        }
    }
}
