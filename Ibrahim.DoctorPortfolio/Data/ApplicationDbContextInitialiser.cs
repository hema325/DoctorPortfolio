using Ibrahim.DoctorPortfolio.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Ibrahim.DoctorPortfolio.Data
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DefaultUserSettings _defaultUser;

        public ApplicationDbContextInitialiser(UserManager<IdentityUser> userManager,
            ApplicationDbContext context,
            IOptions<DefaultUserSettings> defaultUser)
        {
            _userManager = userManager;
            _context = context;
            _defaultUser = defaultUser.Value;
        }

        public async Task InitializeAsync()
        {
            await _context.Database.MigrateAsync();

            if(!_userManager.Users.Any())
            {
                var user = new IdentityUser
                {
                    UserName = _defaultUser.Email,
                    Email = _defaultUser.Email
                };

                await _userManager.CreateAsync(user, _defaultUser.Password);
            }
        }
    }
}
