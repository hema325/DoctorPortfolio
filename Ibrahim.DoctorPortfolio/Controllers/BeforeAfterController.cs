using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Image;
using Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Video;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Enums;
using Ibrahim.DoctorPortfolio.Errors;
using Ibrahim.DoctorPortfolio.Extensions;
using Ibrahim.DoctorPortfolio.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("api/before-after")]
    public class BeforeAfterController: ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BeforeAfterController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("images")]
        [Authorize]
        public async Task<IActionResult> CreateImageAsync(CreateBeforeAfterImageDto dto)
        {
            var image = _mapper.Map<BeforeAfterImage>(dto);

            _context.BeforeAfterImages.Add(image);
            await _context.SaveChangesAsync();

            return Ok(image.Id);
        }

        [HttpDelete("images/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteImageAsync(int id)
        {
            var image = await _context.BeforeAfterImages.FindAsync(id);

            if (image == null)
                return NotFound(ErrorResponse.NotFound());

            _context.BeforeAfterImages.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("images")]
        [Cache]
        public async Task<IActionResult> GetImagesAsync([FromQuery] BeforeAfterImageFilterDto dto)
        {
            var query =  _context.BeforeAfterImages.AsQueryable();

            if (dto.ImageType != null)
                query = query.Where(b => b.ImageType == Enum.Parse<ImageTypes>(dto.ImageType));

            if (dto.ProcedureId != null)
                query = query.Where(b => b.ProcedureId == dto.ProcedureId);

            var images = await query.ProjectTo<BeforeAfterImageDto>(_mapper.ConfigurationProvider)
            .PaginateAsync(dto.PageNumber, dto.PageSize);

            return Ok(images);
        }
        
        [HttpPost("videos")]
        [Authorize]
        public async Task<IActionResult> CreateVideoAsync(CreateBeforeAfterVideoDto dto)
        {
            var video = _mapper.Map<BeforeAfterVideo>(dto);

            _context.BeforeAfterVideos.Add(video);
            await _context.SaveChangesAsync();

            return Ok(video.Id);
        }

        [HttpDelete("videos/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteVideoAsync(int id)
        {
            var video = await _context.BeforeAfterVideos.FindAsync(id);

            if (video == null)
                return NotFound(ErrorResponse.NotFound());

            _context.BeforeAfterVideos.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("videos")]
        [Cache]
        public async Task<IActionResult> GetVideoAsync()
        {
            var videos = await _context.BeforeAfterVideos
                .ProjectTo<BeforeAfterVideoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(videos);
        }
    }
}
