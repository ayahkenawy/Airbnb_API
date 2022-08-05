using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.RoomTypeRepository;
using API_Airbnb.Data.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace API_Airbnb.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ArRoomTypesController : ControllerBase
    {

        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;

        public ArRoomTypesController(IRoomTypeRepository roomTypeRepository, IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }

        // GET: api/ArRoomTypes
        [HttpGet]
        public ActionResult<IEnumerable<RoomTypeReadDTO>> GetArRoomType()
        {
            var list = _roomTypeRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<RoomTypeReadDTO>>(list));
        }

        // GET: api/ArRoomTypes/5
        [HttpGet("{id}")]
        public ActionResult<RoomTypeReadDTO> GetArRoomType(int id)
        {
            var roomType = _roomTypeRepository.GetById(id);
            if (roomType is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (roomType.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<RoomTypeReadDTO>(roomType));
        }

        // PUT: api/ArRoomTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "admin")]
        public ActionResult PutArRoomType(int id, RoomTypeWriteDTO roomTypeWriteDTO)
        {
            var roomTypeEdit = _roomTypeRepository.GetById(id);
            if (roomTypeEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (roomTypeEdit.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            _mapper.Map(roomTypeWriteDTO, roomTypeEdit);
            roomTypeEdit.Modified = DateTime.Now;
            _roomTypeRepository.Update(roomTypeEdit);
            _roomTypeRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Message = "RoomType Updated" });
        }

        // POST: api/ArRoomTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult<ArRoomType> PostArRoomType(RoomTypeWriteDTO roomTypeWriteDTO)
        {
            var count = _roomTypeRepository.GetAll().Count;
            var id = count + 1;
            var roomType = _mapper.Map<ArRoomType>(roomTypeWriteDTO);
            roomType.Modified = DateTime.Now;
            roomType.Created = DateTime.Now;
            roomType.Id = id;
            roomType.Status = true;
            _roomTypeRepository.Add(roomType);
            _roomTypeRepository.SaveChanges();

            return CreatedAtAction("GetArRoomType", new { id = id }, _mapper.Map<RoomTypeReadDTO>(roomType));
        }

        // DELETE: api/ArRoomTypes/5
        [HttpPut("Delete/{id}")]
        [Authorize(Policy = "admin")]
        public ActionResult DeleteArRoomType(int id)
        {
            var roomTypeEdit = _roomTypeRepository.GetById(id);
            if (roomTypeEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            roomTypeEdit.Status = false;
            roomTypeEdit.Modified = DateTime.Now;
            _roomTypeRepository.Update(roomTypeEdit);
            _roomTypeRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Massage = "RoomType Deleted" });
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