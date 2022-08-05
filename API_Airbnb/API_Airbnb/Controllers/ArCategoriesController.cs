
using Microsoft.AspNetCore.Mvc;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.CategoriesRepository;
using API_Airbnb.Data.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;


namespace API_Airbnb.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ArCategoriesController : ControllerBase

{
    public readonly ICategoriesRepository _categoriesRepository;
    public readonly IMapper _mapper;
    public ArCategoriesController(ICategoriesRepository categoriesRepository, IMapper mapper)
    {
        _categoriesRepository = categoriesRepository;
        _mapper = mapper;

    }

    // GET: api/ArCategories
    [HttpGet]
    public ActionResult<IEnumerable<CategoriesReadDTO>> GetArCategories()
    {

        var listFromDb = _categoriesRepository.GetAllWithSub().Where(s => s.Status == true); ;
        return _mapper.Map<List<CategoriesReadDTO>>(listFromDb);

    }

    // GET: api/ArCategories/5
    [HttpGet("{id}")]
    public ActionResult<CategoriesReadDTO> GetArCategories(int id)
    { 
        var catgories = _categoriesRepository.GetByIdWithSub(id);
        if(catgories is null)
        {
            return NotFound(new {Message="Not Found"});
        }
        if (catgories.Status == false)
        {
            return NotFound(new { Message = "Not Found" });
        }
        return _mapper.Map< CategoriesReadDTO>(catgories);

    }


    // PUT: api/ArCategories/5
    [HttpPut("{id}")]
    [Authorize(Policy = "adminAndhost")]
    public IActionResult PutArCategories(int id, ArCategories arCategories)
    {
        if (id != arCategories.Id)
        {
            return BadRequest();
        }
        var categoryToEdit = _categoriesRepository.GetById(id);
        if (categoryToEdit  is null)
        {
            return NotFound(new {Message="Not Found"});
        }
        _mapper.Map(arCategories, categoryToEdit);
        categoryToEdit.Modified = DateTime.Now;
        _categoriesRepository.Update(categoryToEdit);
        _categoriesRepository.SaveChanges();

        return StatusCode(StatusCodes.Status201Created, new { Message = "Category Updated" });
    }

    // POST: api/ArCategories
    [HttpPost]
    [Authorize(Policy = "adminAndhost")]
    public ActionResult<ArCategories> PostArCategories(CategoryWriteDTO arCategories)
    {

        var count = _categoriesRepository.GetAll().Count;
        var id = count + 1;
        var category = _mapper.Map<ArCategories>(arCategories);
        category.Modified = DateTime.Now;
        category.Created = DateTime.Now;
        category.Id = id;
        category.Status = true;
        _categoriesRepository.Add(category);
        _categoriesRepository.SaveChanges();
        return CreatedAtAction(actionName: nameof(GetArCategories), routeValues: new { id = id }, _mapper.Map<CategoriesReadDTO>(category));
    }

    // DELETE: api/ArCategories/5
    [HttpPut]
    [Authorize(Policy = "adminAndhost")]
    [Route("Delete/{id}")]
    public IActionResult DeleteArCategories(int id)
    {
        var categoryEdit = _categoriesRepository.GetById(id);
        if (categoryEdit is null)
        {
            return NotFound(new { Message = "Not Found" });
        }
        categoryEdit.Status = false;
        categoryEdit.Modified = DateTime.Now;
        _categoriesRepository.Update(categoryEdit);
        _categoriesRepository.SaveChanges();
        return StatusCode(StatusCodes.Status201Created, new { Message = "Category Deleted" });
    }

}
