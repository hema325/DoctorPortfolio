using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos.FAQ.Text;
using Ibrahim.DoctorPortfolio.Dtos.FAQ.Video;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Enums;
using Ibrahim.DoctorPortfolio.Errors;
using Ibrahim.DoctorPortfolio.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("faq")]
    public class FAQController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FAQController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("texts")]
        [Authorize]
        public async Task<IActionResult> CreateFAQTextAsync(CreateOrUpdateFAQTextDto dto)
        {
            var question = _mapper.Map<FAQText>(dto);

            _context.FAQTexts.Add(question);
            await _context.SaveChangesAsync();

            return Ok(question.Id);
        }

        [HttpPut("texts/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateFAQTextAsync(int id, CreateOrUpdateFAQTextDto dto)
        {
            var question = await _context.FAQTexts.FindAsync(id);

            if (question == null)
                return NotFound(ErrorResponse.NotFound());

            _mapper.Map(dto, question);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("texts/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFAQTextAsync(int id)
        {
            var question = await _context.FAQTexts.FindAsync(id);

            if (question == null)
                return NotFound(ErrorResponse.NotFound());

            _context.FAQTexts.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("texts/{id}")]
        [Cache]
        public async Task<IActionResult> GetFAQTextByIdAsync(int id)
        {
            var faq = await _context.FAQTexts.FindAsync(id);

            if (faq == null)
                return NotFound(ErrorResponse.NotFound());

            return Ok(_mapper.Map<FAQTextDto>(faq));
        }

        [HttpGet("texts")]
        [Cache]
        public async Task<IActionResult> GetFAQTextAsync([FromQuery] FAQTextFilterDto dto)
        {
            var query = _context.FAQTexts.AsQueryable();

            if (dto.Type != null)
                query = query.Where(q => q.Type == Enum.Parse<QuestionTypes>(dto.Type));

            var questions = await query.ProjectTo<FAQTextDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(questions);
        }

        [HttpPost("videos")]
        [Authorize]
        public async Task<IActionResult> CreateFAQVideoAsync(CreateFAQVideoDto dto)
        {
            var video = _mapper.Map<FAQVideo>(dto);

            _context.FAQVideos.Add(video);
            await _context.SaveChangesAsync();

            return Ok(video.Id);
        }

        [HttpDelete("videos/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFAQVideoAsync(int id)
        {
            var video = await _context.FAQVideos.FindAsync(id);

            if (video == null)
                return NotFound(ErrorResponse.NotFound());

            _context.FAQVideos.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("videos")]
        [Cache]
        public async Task<IActionResult> GetFAQVideoAsync()
        {
            var videos = await _context.FAQVideos.ProjectTo<FAQVideoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(videos);
        }
    }
}
