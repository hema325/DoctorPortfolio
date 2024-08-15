using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos;
using Ibrahim.DoctorPortfolio.Dtos.Review.Text;
using Ibrahim.DoctorPortfolio.Dtos.Review.Video;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Errors;
using Ibrahim.DoctorPortfolio.Extensions;
using Ibrahim.DoctorPortfolio.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("reviews")]
    public class ReviewsController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReviewsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("texts")]
        [Authorize]
        public async Task<IActionResult> CreateReviewTextAsync(CreateOrUpdateReviewTextDto dto)
        {
            var review = _mapper.Map<ReviewText>(dto);

            _context.ReviewTexts.Add(review);
            await _context.SaveChangesAsync();

            return Ok(review.Id);
        }

        [HttpPut("texts/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateReviewTextAsync(int id, CreateOrUpdateReviewTextDto dto)
        {
            var review = await _context.ReviewTexts.FindAsync(id);

            if (review == null)
                return BadRequest(ErrorResponse.NotFound());

            _mapper.Map(dto, review);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("texts/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteReviewTextAsync(int id)
        {
            var review = await _context.ReviewTexts.FindAsync(id);

            if (review == null)
                return BadRequest(ErrorResponse.NotFound());

            _context.ReviewTexts.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("texts")]
        [Cache]
        public async Task<IActionResult> GetReviewTextAsync([FromQuery] PaginationFilterDto dto)
        {
            var reviews = await _context.ReviewTexts.ProjectTo<ReviewTextDto>(_mapper.ConfigurationProvider)
                .PaginateAsync(dto.PageNumber, dto.PageSize);

            return Ok(reviews);
        }

        [HttpPost("videos")]
        [Authorize]
        public async Task<IActionResult> CreateReviewVideoAsync(CreateReviewVideoDto dto)
        {
            var video = _mapper.Map<ReviewVideo>(dto);

            _context.ReviewVideos.Add(video);
            await _context.SaveChangesAsync();

            return Ok(video.Id);
        }

        [HttpDelete("videos/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteReviewVideoAsync(int id)
        {
            var video = await _context.ReviewVideos.FindAsync(id);

            if (video == null)
                return BadRequest(ErrorResponse.NotFound());

            _context.ReviewVideos.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("videos")]
        [Cache]
        public async Task<IActionResult> GetReviewVideosAsync()
        {
            var videos = await _context.ReviewVideos.ProjectTo<ReviewVideoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(videos);
        }
    }
}
