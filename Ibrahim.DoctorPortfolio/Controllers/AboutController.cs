using AutoMapper;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos.About;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Enums;
using Ibrahim.DoctorPortfolio.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("about")]
    public class AboutController: ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AboutController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Cache]
        public async Task<IActionResult> GetAboutAsync()
        {
            var keyValue = await _context.KeyValues.FirstOrDefaultAsync(k => k.Key == Sections.About.ToString());

            if (keyValue == null)
                return NoContent();

            var about = JsonSerializer.Deserialize<About>(keyValue.Value);
            
            return Ok(_mapper.Map<AboutDto>(about));
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateAboutAsync(About about)
        {
            var keyValue = await _context.KeyValues.FirstOrDefaultAsync(k => k.Key == Sections.About.ToString());

            if (keyValue == null)
                keyValue = new KeyValue
                {
                    Key = Sections.About.ToString(),
                };

            keyValue.Value = JsonSerializer.Serialize(about);

            _context.KeyValues.Update(keyValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("/shared")]
        [Cache]
        public async Task<IActionResult> GetContactInfoAsync()
        {
            var keyValue = await _context.KeyValues.FirstOrDefaultAsync(k => k.Key == Sections.Shared.ToString());

            if (keyValue == null)
                return NoContent();

            var shared = JsonSerializer.Deserialize<Shared>(keyValue.Value);

            return Ok(_mapper.Map<SharedDto>(shared));
        }

        [HttpPut("/shared")]
        [Authorize]
        public async Task<IActionResult> UpdateContactInfoAsync(Shared shared)
        {
            var keyValue = await _context.KeyValues.FirstOrDefaultAsync(k => k.Key == Sections.Shared.ToString());

            if (keyValue == null)
                keyValue = new KeyValue
                {
                    Key = Sections.Shared.ToString(),
                };

            keyValue.Value = JsonSerializer.Serialize(shared);

            _context.KeyValues.Update(keyValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
