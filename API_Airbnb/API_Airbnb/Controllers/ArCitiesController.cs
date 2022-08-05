using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Repositories.CityRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Airbnb.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ArCitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public ArCitiesController(ICityRepository cityRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var list = _cityRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<CityReadDTO>>(list));
        }
        [HttpGet]
        [Route("GetByCountryID/{Id}")]
        public ActionResult GetByCountryID(int Id)
        {
            var list = _cityRepository.GetByCountryID(Id).Where(s => s.Status == true);
            return Ok(_mapper.Map<List<CityReadDTO>>(list));
        }
    }
}
