using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos.Category;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Errors;
using Ibrahim.DoctorPortfolio.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("categories")]
    public class CategoriesController: ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(CreateOrUpdateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);

            if (await _context.Categories.AnyAsync(c => c.NameEn == dto.NameEn))
                return BadRequest(ErrorResponse.BadRequest("Category name english is already exists."));
            
            if (await _context.Categories.AnyAsync(c => c.NameAr == dto.NameAr))
                return BadRequest(ErrorResponse.BadRequest("Category name arabic is already exists."));

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category.Id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, CreateOrUpdateCategoryDto dto)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound(ErrorResponse.NotFound());

            if (await _context.Categories.AnyAsync(c => c.NameEn == dto.NameEn && c.Id != id))
                return BadRequest(ErrorResponse.BadRequest("Category name english is already exists."));

            if (await _context.Categories.AnyAsync(c => c.NameAr == dto.NameAr && c.Id != id))
                return BadRequest(ErrorResponse.BadRequest("Category name arabic is already exists."));

            _mapper.Map(dto, category);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
                return NotFound(ErrorResponse.NotFound());

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpGet("{id}")]
        [Cache]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if(category == null)
                return NotFound(ErrorResponse.NotFound());

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpGet]
        [Cache]
        public async Task<IActionResult> GetAsync()
        {
            var categories = await _context.Categories.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(categories);
        }
    }
}
