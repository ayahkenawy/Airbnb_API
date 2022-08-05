using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.PropertyImagesRepository;
using API_Airbnb.Data.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace API_Airbnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArPropertyImagesController : ControllerBase

    {
        public readonly IPropertyImagesRepository _propertyImagesRepository;
        public readonly IMapper _mapper;
        public ArPropertyImagesController(IPropertyImagesRepository propertyImagesRepository, IMapper mapper)
        {
            _propertyImagesRepository = propertyImagesRepository;
            _mapper = mapper;

        }

        // GET: api/ArPropertyImages
        [HttpGet]
        public ActionResult<IEnumerable<PropertyImagesReadDTO>> GetArPropertyImages()
        {

            var listFromDb = _propertyImagesRepository.GetAll().Where(s => s.Status == true); ;
            return _mapper.Map<List<PropertyImagesReadDTO>>(listFromDb);

        }

        // GET: api/ArPropertyImages/5
        [HttpGet("{id}")]
        public ActionResult<PropertyImagesReadDTO> GetArPropertyImages(int id)
        {
            var propertyImages = _propertyImagesRepository.GetById(id);
            if (propertyImages is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (propertyImages.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return _mapper.Map<PropertyImagesReadDTO>(propertyImages);

        }

        // PUT: api/ArPropertyImages/5


        [Authorize(Policy = "adminAndhost")]
        [HttpPut("{id}")]
        public IActionResult PutArPropertyImages(int id, PropertyImagesWriteDTO arPropertyImages)
        {
           
            var propertyImagesToEdit = _propertyImagesRepository.GetById(id);
            if (propertyImagesToEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == propertyImagesToEdit.AddedByUser || User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                _mapper.Map(arPropertyImages, propertyImagesToEdit);
                _propertyImagesRepository.Update(propertyImagesToEdit);
                _propertyImagesRepository.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, new { Message = "PropertyImages Updated" });
            }
            else { return NotFound(new { Message = "You Can't Update This Property Image" }); }
        }

        // POST: api/ArPropertyImages
        [HttpPost]


        [Authorize(Policy = "adminAndhost")]
        public ActionResult<ArPropertyImages> PostArPropertyImages(PropertyImagesWriteDTO arPropertyImages)
        {

            var count = _propertyImagesRepository.GetAll().Count;
            var id = count + 1;
            var propertyImages = _mapper.Map<ArPropertyImages>(arPropertyImages);
            propertyImages.Created = DateTime.Now;
            propertyImages.Id = id;
            propertyImages.AddedByUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            propertyImages.Status = true;
            _propertyImagesRepository.Add(propertyImages);
            _propertyImagesRepository.SaveChanges();
            return CreatedAtAction(actionName: nameof(GetArPropertyImages), routeValues: new { id = id }, _mapper.Map<PropertyImagesReadDTO>(propertyImages));
        }

        // DELETE: api/ArPropertyImages/5


        [Authorize(Policy = "adminAndhost")]
        [HttpPut]
        [Route("Delete/{id}")]
        public IActionResult DeleteArPropertyImages(int id)
        {
            var propertyImagesEdit = _propertyImagesRepository.GetById(id);
            if (propertyImagesEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == propertyImagesEdit.AddedByUser || User.FindFirstValue(ClaimTypes.Role).Contains("admin"))
            {
                propertyImagesEdit.Status = false;
                _propertyImagesRepository.Update(propertyImagesEdit);
                _propertyImagesRepository.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { Message = "Property Deleted" });
            }
            else { return NotFound(new { Message = "You Can't Delete This Property Image" }); }
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
