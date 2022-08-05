using API_Airbnb.Data.DTOs;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;
using API_Airbnb.Data.Repositories.PromoCodeRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Airbnb.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ArPromoCodesController : ControllerBase
    {
        private readonly IPromoCodeRepository _promoCodeRepository;
        private readonly IMapper _mapper;

        public ArPromoCodesController(IPromoCodeRepository promoCodeRepository,IMapper mapper)
        {
            _promoCodeRepository = promoCodeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public ActionResult GetAll()
        {
            var list = _promoCodeRepository.GetAll().Where(s => s.Status == true);
            return Ok(_mapper.Map<List<PromoCodeReadDTO>>(list));
        }
        [HttpGet]
        [Route("GetAllWithTrans")]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult GetAllWithTrans()
        {
            return Ok(_mapper.Map<List< PromoCodeTransDTO >>(_promoCodeRepository.GetAllWithTrans()));
            //return Ok(_promoCodeRepository.GetAllWithTrans());
        }
        [HttpGet("{Id}")]
        [Authorize]
        public ActionResult GetById(int Id)
        {
            var promoCode = _promoCodeRepository.GetById(Id);
            if (promoCode is null)
            {
                return NotFound(new {Message="Not Found"});
            }
            if (promoCode.Status == false)
            {
                return NotFound(new {Message="Not Found"});
            }
            return Ok(_mapper.Map<PromoCodeReadDTO>(promoCode));
        }
        [HttpGet]
        [Route("GetByIdWithTrans/{Id}")]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult GetByIdWithTrans(int Id)
        {
            var promoCode = _promoCodeRepository.GetByIdWithTrans(Id);
            if (promoCode is null)
            {
                return NotFound(new {Message="Not Found"});
            }
            return Ok(_mapper.Map<PromoCodeTransDTO>(promoCode));
        }
        [Route("Update/{Id}")]
        [HttpPut]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult Update(int Id, PromoCodeDTO promoCodeDTO)
        {
            var promoCodeEdit = _promoCodeRepository.GetById(Id);
            if (promoCodeEdit is null)
            {
                return NotFound(new {Message="Not Found"});
            }
            _mapper.Map(promoCodeDTO,promoCodeEdit);
            promoCodeEdit.Modified = DateTime.Now;
            _promoCodeRepository.Update(promoCodeEdit);
            _promoCodeRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Message = "PromoCode Updated" });
        }
        [HttpPost]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult AddPromoCode(PromoCodeDTO promoCodeDTO)
        {
            var count = _promoCodeRepository.GetAll().Count;
            var id = count + 1;
            var promo = _mapper.Map<ArPromoCodes>(promoCodeDTO);
            promo.Modified = DateTime.Now;
            promo.Created = DateTime.Now;
            promo.Id = id;
            promo.Status = true;
            _promoCodeRepository.Add(promo);
            _promoCodeRepository.SaveChanges();
            return CreatedAtAction(actionName: nameof(GetById), routeValues: new { id = id }, _mapper.Map<PromoCodeReadDTO>(promo));
        }
        [Route("Delete/{Id}")]
        [HttpPut]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult Delete(int Id)
        {
            var promoCodeEdit = _promoCodeRepository.GetById(Id);
            if (promoCodeEdit is null)
            {
                return NotFound(new {Message="Not Found"});
            }
          
            promoCodeEdit.Status = false;
            promoCodeEdit.Modified = DateTime.Now;
            _promoCodeRepository.Update(promoCodeEdit);
            _promoCodeRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Message = "PromoCode Deleted" });
        }
    }
}
