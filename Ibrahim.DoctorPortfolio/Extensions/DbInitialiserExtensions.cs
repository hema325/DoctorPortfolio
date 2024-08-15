using Ibrahim.DoctorPortfolio.Data;

namespace Ibrahim.DoctorPortfolio.Extensions
{
    public static class DbInitialiserExtensions
    {
        public static async Task<IServiceProvider> InitialiseDbAsync(this IServiceProvider provider)
        {
            var scope = provider.CreateScope();
            
            await scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>()
                .InitializeAsync();

            return provider;
        }
    }
}
