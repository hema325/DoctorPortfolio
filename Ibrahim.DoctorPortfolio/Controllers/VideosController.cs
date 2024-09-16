using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos.Video;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Enums;
using Ibrahim.DoctorPortfolio.Errors;
using Ibrahim.DoctorPortfolio.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("api/videos")]
    public class VideosController: ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VideosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(CreateOrUpdateVideoDto dto)
        {
            var video = _mapper.Map<Video>(dto);

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return Ok(video.Id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, CreateOrUpdateVideoDto dto)
        {
            var video = await _context.Videos.FindAsync(id);

            if (video == null)
                return NotFound(ErrorResponse.NotFound());

            _mapper.Map(dto, video);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var video = await _context.Videos.FindAsync(id);

            if (video == null)
                return NotFound(ErrorResponse.NotFound());

            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        [Cache]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var video = await _context.Videos.FindAsync(id);

            if(video == null)
                return NotFound(ErrorResponse.NotFound());

            return Ok(_mapper.Map<VideoDto>(video));
        }

        [HttpGet]
        [Cache]
        public async Task<IActionResult> GetAsync([FromQuery] VideoFilterDto dto)
        {
            var query = _context.Videos.AsQueryable();

            if (dto.Type != null)
                query = query.Where(v => v.Type == Enum.Parse<VideoTypes>(dto.Type));

            var videos = await query.ProjectTo<VideoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(videos);
        }
    }
}
