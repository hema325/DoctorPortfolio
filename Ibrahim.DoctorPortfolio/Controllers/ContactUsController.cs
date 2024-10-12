using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos.ContactUs;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("api/contact-us")]
    public class ContactUsController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactUsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateContactUsDto dto)
        {
            var contactUs = _mapper.Map<ContactUs>(dto);

            _context.ContactUs.Add(contactUs);
            await _context.SaveChangesAsync();

            return Ok(contactUs.Id);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var contactUs = await _context.ContactUs.FindAsync(id);

            if (contactUs == null)
                return NotFound(ErrorResponse.NotFound());

            _context.ContactUs.Remove(contactUs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var contactUs = await _context.ContactUs
                .ProjectTo<ContactUsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(contactUs);
        }
    }
}
