using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.BookingsRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Airbnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArBookingsController : ControllerBase
    {
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IMapper _mapper;

        public ArBookingsController(IBookingsRepository bookingsRepository, IMapper mapper)
        {
            _bookingsRepository = bookingsRepository;
            _mapper = mapper;
        }

        // GET: api/ArBookings
        [HttpGet]
        [Authorize(Policy ="admin")]
        public ActionResult<IEnumerable<BookingsReadDTO>> GetArBookings()
        {
            var list = _bookingsRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<BookingsReadDTO>>(list));
        }

        // GET: api/ArBookings/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<BookingsReadDTO> GetArBookings(int id)
        {
            var bookings = _bookingsRepository.GetById(id);
            if (bookings is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (bookings.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<BookingsReadDTO>(bookings));
        }

        // PUT: api/ArBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult PutArBookings(int id, BookingsDTO bookingsDTO)
        {
            var bookingsEdit = _bookingsRepository.GetById(id);
            if (bookingsEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (bookingsEdit.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId!=bookingsEdit.UserId )
            {
                return NotFound(new { Message = "You Can't Update This Booking" });
            }
            _mapper.Map(bookingsDTO, bookingsEdit);
            bookingsEdit.Modified = DateTime.Now;
            _bookingsRepository.Update(bookingsEdit);
            _bookingsRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Message = "Bookings Updated" });
        }

        // POST: api/ArBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public ActionResult AddArBookings(BookingsDTO bookingsDTO)
        {
            var count = _bookingsRepository.GetAll().Count;
            var id = count + 1;
            var bookings = _mapper.Map<ArBookings>(bookingsDTO);
            bookings.Modified = DateTime.Now;
            bookings.Created = DateTime.Now;
            bookings.Id = id;
            bookings.Status = true;
            bookings.BookingDate = DateTime.Now;
            bookings.UserId=  User.FindFirstValue(ClaimTypes.NameIdentifier);
            _bookingsRepository.Add(bookings);
            _bookingsRepository.SaveChanges();
            return CreatedAtAction(actionName: nameof(GetArBookings), routeValues: new { id = id }, _mapper.Map<BookingsReadDTO>(bookings));

        }

        // DELETE: api/ArBookings/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteArBookings(int id)
        {
            var BookingsEdit = _bookingsRepository.GetById(id);
            if (BookingsEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId != BookingsEdit.UserId)
            {
                return NotFound(new { Message = "You Can't Delete This Booking" });
            }
            BookingsEdit.Status = false;
            BookingsEdit.Modified = DateTime.Now;
            _bookingsRepository.Update(BookingsEdit);
            _bookingsRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Massage = "Bookings Deleted" });
        }
    }
}
