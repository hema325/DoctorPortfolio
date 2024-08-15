using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ibrahim.DoctorPortfolio.Data;
using Ibrahim.DoctorPortfolio.Dtos;
using Ibrahim.DoctorPortfolio.Dtos.Category;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Errors;
using Ibrahim.DoctorPortfolio.Extensions;
using Ibrahim.DoctorPortfolio.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("procedures")]
    public class ProceduresController: ApiControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProceduresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(CreateOrUpdateProcedureDto dto)
        {
            var procedure = _mapper.Map<Procedure>(dto);

            _context.Procedures.Add(procedure);
            await _context.SaveChangesAsync();

            return Ok(procedure.Id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, CreateOrUpdateProcedureDto dto)
        {
            var procedure = await _context.Procedures
                .Include(c=>c.Sections)
                .FirstOrDefaultAsync(c=>c.Id == id);

            if (procedure == null)
                return NotFound(ErrorResponse.NotFound());

            _mapper.Map(dto, procedure);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var procedure = await _context.Procedures.FindAsync(id);

            if (procedure == null)
                return NotFound(ErrorResponse.NotFound());

            _context.Procedures.Remove(procedure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        [Cache]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var procedure = await _context.Procedures
               .ProjectTo<ProcedureDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(c => c.Id == id);

            if (procedure == null)
                return NotFound(ErrorResponse.NotFound());

            return Ok(procedure);
        }

        [HttpGet]
        [Cache]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationFilterDto dto)
        {
            var procedures = await _context.Procedures
               .ProjectTo<ProcedureBriefDto>(_mapper.ConfigurationProvider)
               .PaginateAsync(dto.PageNumber, dto.PageSize);

            if (procedures == null)
                return NotFound(ErrorResponse.NotFound());

            return Ok(procedures);
        }
    }
}
