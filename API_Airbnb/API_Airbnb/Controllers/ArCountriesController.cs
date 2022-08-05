using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Repositories.CountryRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Airbnb.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ArCountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public ArCountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var list = _countryRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<CountryReadDTO>>(list));
        }
        [HttpGet("{Id}")]
        public ActionResult GetById(int Id)
        {
            var Country = _countryRepository.GetById(Id);
            if (Country is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            if (Country.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return Ok(_mapper.Map<CountryReadDTO>(Country));
        }
    }
}
