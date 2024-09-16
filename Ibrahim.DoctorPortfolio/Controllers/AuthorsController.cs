using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos.Author;
using Ibrahim.DoctorPortfolio.Dtos.Category;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Errors;
using Ibrahim.DoctorPortfolio.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("api/authors")]
    public class AuthorsController: ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(CreateOrUpdateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);

            if (await _context.Authors.AnyAsync(a => a.NameEn == dto.NameEn))
                return BadRequest(ErrorResponse.BadRequest("Author name english is already exists."));

            if (await _context.Authors.AnyAsync(c => c.NameAr == dto.NameAr))
                return BadRequest(ErrorResponse.BadRequest("Author name arabic is already exists."));

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return Ok(author.Id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, CreateOrUpdateAuthorDto dto)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
                return NotFound(ErrorResponse.NotFound());

            if (await _context.Authors.AnyAsync(a => a.NameEn == dto.NameEn && a.Id != id))
                return BadRequest(ErrorResponse.BadRequest("Author name english is already exists."));

            if (await _context.Authors.AnyAsync(a => a.NameAr == dto.NameAr && a.Id != id))
                return BadRequest(ErrorResponse.BadRequest("Author name arabic is already exists."));

            _mapper.Map(dto, author);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
                return NotFound(ErrorResponse.NotFound());

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpGet("{id}")]
        [Cache]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
                return NotFound(ErrorResponse.NotFound());

            return Ok(_mapper.Map<AuthorDto>(author));
        }
        
        [HttpGet]
        [Cache]
        public async Task<IActionResult> GetAsync()
        {
            var authors = await _context.Authors.ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(authors);
        }
    }
}
