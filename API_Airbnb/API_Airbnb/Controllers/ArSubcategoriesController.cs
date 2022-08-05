using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.SubcategoriesRepository;
using AutoMapper;
using API_Airbnb.Data.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API_Airbnb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArSubcategoriesController : ControllerBase
    {
        public readonly ISubcategoriesRepository _subcategoriesRepository;
        public readonly IMapper _mapper;
        public ArSubcategoriesController(ISubcategoriesRepository subcategoriesRepository, IMapper mapper)
        {
            _subcategoriesRepository = subcategoriesRepository;
            _mapper = mapper;

        }

        // GET: api/ArSubcategories
        [HttpGet]
        public ActionResult<IEnumerable<SubcategoriesReadDTO>> GetArSubcategories()
        {

            var listFromDb = _subcategoriesRepository.GetAll().Where(s => s.Status == true); ;
            return _mapper.Map<List<SubcategoriesReadDTO>>(listFromDb);

        }

        // GET: api/ArSubcategories/5
        [HttpGet("{id}")]
        public ActionResult<SubcategoriesReadDTO> GetArCategories(int id)
        {
            var subcatgories = _subcategoriesRepository.GetById(id);
            if (subcatgories is null)
            {
                return NotFound(new {Message="Not Found"});
            }
            if (subcatgories.Status == false)
            {
                return NotFound(new { Message = "Not Found" });
            }
            return _mapper.Map<SubcategoriesReadDTO>(subcatgories);

        }

        // PUT: api/ArSubcategories/5
        [HttpPut("{id}")]
        [Authorize(Policy = "admin")]
        public IActionResult PutArCategories(int id, ArSubcategories arsubcategories)
        {
            if (id != arsubcategories.Id)
            {
                return BadRequest();
            }
            var subcategoryToEdit = _subcategoriesRepository.GetById(id);
            if (subcategoryToEdit is null)
            {
                return NotFound(new {Message="Not Found"});
            }
            _mapper.Map(arsubcategories, subcategoryToEdit);
            subcategoryToEdit.Modified = DateTime.Now;
            _subcategoriesRepository.Update(subcategoryToEdit);
            _subcategoriesRepository.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, new { Message = "SubCategory Updated" });
        }

        // POST: api/ArSubcategories
        [HttpPost]
        [Authorize(Policy = "adminAndhost")]
        public ActionResult<ArSubcategories> PostArSubategories(SubCategoryWriteDTO arSubcategories)
        {

            var count = _subcategoriesRepository.GetAll().Count;
            var id = count + 1;
            var subcategory = _mapper.Map<ArSubcategories>(arSubcategories);
            subcategory.Modified = DateTime.Now;
            subcategory.Created = DateTime.Now;
            subcategory.Id = id;
            subcategory.Status = true;
            _subcategoriesRepository.Add(subcategory);
            _subcategoriesRepository.SaveChanges();
            return CreatedAtAction(actionName: nameof(GetArCategories), routeValues: new { id = id }, _mapper.Map<SubcategoriesReadDTO>(subcategory));
        }

        // DELETE: api/ArSubcategories/5
        [HttpPut]
        [Authorize(Policy = "admin")]
        [Route("Delete/{id}")]
        public IActionResult DeleteArSubcategories(int id)
        {
            var subCategoryEdit = _subcategoriesRepository.GetById(id);
            if (subCategoryEdit is null)
            {
                return NotFound(new { Message = "Not Found" });
            }
            subCategoryEdit.Status = false;
            subCategoryEdit.Modified = DateTime.Now;
            _subcategoriesRepository.Update(subCategoryEdit);
            _subcategoriesRepository.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, new { Message = "Subcategory Deleted" });
        }


    }
}
