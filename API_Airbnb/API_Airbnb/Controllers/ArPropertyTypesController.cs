using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.PropertyTypeRepository;
using API_Airbnb.Data.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace API_Airbnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArPropertyTypesController : ControllerBase
    {
        private readonly IPropertyTypeRepository _propertyTypeRepository;
        private readonly IMapper _mapper;

        public ArPropertyTypesController(IPropertyTypeRepository propertyTypeRepository,IMapper mapper)
        {
            _propertyTypeRepository = propertyTypeRepository;
            _mapper = mapper;
        }

        // GET: api/ArPropertyTypes
        [HttpGet]
        public ActionResult<IEnumerable<PropertyTypeReadDTO>> GetArPropertyType()
        {
            var list = _propertyTypeRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<PropertyTypeReadDTO>>(list));
        }

        // GET: api/ArPropertyTypes/5
        [HttpGet("{id}")]
        public ActionResult<PropertyTypeReadDTO> GetArPropertyType(int id)
        {
            var propertyType = _propertyTypeRepository.GetById(id);
            if (propertyType is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (propertyType.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<PropertyTypeReadDTO>(propertyType));
        }

        // PUT: api/ArPropertyTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult PutArPropertyType(int id, PropertyTypeWriteDTO propertyTypeWriteDTO)
        {
            var propertyTypeEdit = _propertyTypeRepository.GetById(id);
            if (propertyTypeEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (propertyTypeEdit.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            _mapper.Map(propertyTypeWriteDTO, propertyTypeEdit);
            propertyTypeEdit.Modified = DateTime.Now;
            _propertyTypeRepository.Update(propertyTypeEdit);
            _propertyTypeRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Message = "PropertyType Updated" });
        }

        // POST: api/ArPropertyTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult<ArPropertyType> PostArPropertyType(PropertyTypeWriteDTO propertyTypeWriteDTO)
        {
            var count = _propertyTypeRepository.GetAll().Count;
            var id = count + 1;
            var propertyType = _mapper.Map<ArPropertyType>(propertyTypeWriteDTO);
            propertyType.Modified = DateTime.Now;
            propertyType.Created = DateTime.Now;
            propertyType.Id = id;
            propertyType.Status = true;
            _propertyTypeRepository.Add(propertyType);
            _propertyTypeRepository.SaveChanges();

            return CreatedAtAction("GetArPropertyType", new { id = id }, _mapper.Map<PropertyTypeReadDTO>(propertyType));
        }
        [Authorize(Policy = "admin")]
        // DELETE: api/ArPropertyTypes/5
        [Route("Delete/{Id}")]
        [HttpPut]
        public IActionResult DeleteArPropertyType(int id)
        {
            var propertyTypeEdit = _propertyTypeRepository.GetById(id);
            if (propertyTypeEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            propertyTypeEdit.Status = false;
            propertyTypeEdit.Modified = DateTime.Now;
            _propertyTypeRepository.Update(propertyTypeEdit);
            _propertyTypeRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Massage = "PropertyType Deleted" });
        }

        [HttpPost]
        [Route("UploadImg")]
        [Authorize(Policy = "adminAndhost")]
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
