using System.ComponentModel.DataAnnotations;

namespace Ibrahim.DoctorPortfolio.Dtos.Account
{
    public class RegisterUserDto
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
