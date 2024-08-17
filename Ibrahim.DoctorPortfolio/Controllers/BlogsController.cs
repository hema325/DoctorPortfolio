using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos;
using Ibrahim.DoctorPortfolio.Dtos.Blog;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Errors;
using Ibrahim.DoctorPortfolio.Extensions;
using Ibrahim.DoctorPortfolio.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("blogs")]
    public class BlogsController: ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BlogsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(CreateOrUpdateBlogDto dto)
        {
            var blog = _mapper.Map<Blog>(dto);

            blog.Categories = await _context.Categories.Where(c => dto.CategoryIds.Contains(c.Id)).ToListAsync();

            if (blog.Categories.Count() != dto.CategoryIds.Count())
                return BadRequest(ErrorResponse.BadRequest("One or more ids wasn't found."));
            
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return Ok(blog.Id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, CreateOrUpdateBlogDto dto)
        {
            var blog = await _context.Blogs.Include(b=>b.Categories).FirstOrDefaultAsync(b=>b.Id == id);

            if (blog == null)
                return NotFound(ErrorResponse.NotFound());

            blog.Categories = await _context.Categories.Where(c => dto.CategoryIds.Contains(c.Id)).ToListAsync();

            if (blog.Categories.Count() != dto.CategoryIds.Count())
                return BadRequest(ErrorResponse.BadRequest("One or more ids wasn't found."));

            _mapper.Map(dto, blog);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
                return NotFound(ErrorResponse.NotFound());

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        [Cache]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var blog = await _context.Blogs.ProjectTo<BlogDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null)
                return NotFound(ErrorResponse.NotFound());

            return Ok(blog);
        }

        [HttpGet]
        [Cache]
        public async Task<IActionResult> GetAsync([FromQuery] BlogFilterDto dto)
        {
            var query = _context.Blogs.AsQueryable();

            if (dto.CategoryId != null)
                query = query.Where(b => b.Categories.Any(c => c.Id == dto.CategoryId));

            if(dto.AuthorId != null)
                query = query.Where(b => b.AuthorId == dto.AuthorId);

            var blogs = await query.ProjectTo<BlogBriefDto>(_mapper.ConfigurationProvider)
                .PaginateAsync(dto.PageNumber, dto.PageSize);

            return Ok(blogs);
        } 
        
        [HttpGet("latest")]
        [Cache]
        public async Task<IActionResult> GetLatestAsync([FromQuery] PaginationFilterDto dto)
        {
            var blogs = await _context.Blogs
                .OrderByDescending(b=>b.WrittenOn)
                .ProjectTo<BlogBriefDto>(_mapper.ConfigurationProvider)
                .PaginateAsync(dto.PageNumber, dto.PageSize);

            return Ok(blogs);
        }

        [HttpGet("{id}/related")]
        [Cache]
        public async Task<IActionResult> GetRelatedAsync(int id, [FromQuery] PaginationFilterDto dto)
        {
            var blogs = await _context.Blogs.Where(b => b.Categories.Any(c1 => _context.Categories.Where(c => c.Blogs.Any(b => b.Id == id)).Any(c2 => c1.Id == c2.Id)))
                .ProjectTo<BlogBriefDto>(_mapper.ConfigurationProvider).PaginateAsync(dto.PageNumber, dto.PageSize);

            return Ok(blogs);
        }

        [HttpGet("{id}/next-previous")]
        public async Task<IActionResult> GetNextPreviousAsync(int id)
        {
            var previous = await _context.Blogs.Where(b => b.Id < id)
                .OrderByDescending(b => b.Id)
                .ProjectTo<BlogBriefDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            var next = await _context.Blogs.Where(b => b.Id > id)
                .OrderBy(b => b.Id)
                .ProjectTo<BlogBriefDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (previous == null && next == null)
                return NoContent();

            var nextPrevious = new BlogNextPreviousDto
            {
                Previous = previous,
                Next = next
            };

            return Ok(nextPrevious);
        }
    }
}
