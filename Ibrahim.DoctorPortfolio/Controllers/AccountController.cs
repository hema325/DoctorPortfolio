using Ibrahim.DoctorPortfolio.Dtos.Account;
using Ibrahim.DoctorPortfolio.Errors;
using Ibrahim.DoctorPortfolio.Extensions;
using Ibrahim.DoctorPortfolio.Services.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ibrahim.DoctorPortfolio.Controllers
{
    [Route("api/account")]
    public class AccountController: ApiControllerBase
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(IJwtProvider jwtProvider, UserManager<IdentityUser> userManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> RegisterAsync(RegisterUserDto dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
                return Ok(user.Id);

            var errors = result.Errors
                .Select(e => e.Description);

            return BadRequest(ValidationResponse.Create(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return BadRequest(ErrorResponse.BadRequest("Email or password is not correct."));

            var result = new AuthResult
            {
                Id = user.Id,
                Email = user.Email,
                Token = _jwtProvider.Create(user)
            };

            return Ok(result);
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(User.Id()!);

            var result = await _userManager.ChangePasswordAsync(user!, dto.OldPassword, dto.NewPassword);

            if (result.Succeeded)
                return NoContent();

            var errors = result.Errors
                .Select(e => e.Description);

            return BadRequest(ValidationResponse.Create(errors));
        }

    }
}
