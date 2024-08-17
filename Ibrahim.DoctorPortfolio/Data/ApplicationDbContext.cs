using Ibrahim.DoctorPortfolio.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ibrahim.DoctorPortfolio.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Procedure> Procedures { get; private set; }
        public DbSet<Section> Sections { get; private set; }
        public DbSet<BeforeAfterImage> BeforeAfterImages { get; private set; }
        public DbSet<BeforeAfterVideo> BeforeAfterVideos { get; private set; }
        public DbSet<ReviewText> ReviewTexts { get; private set; }
        public DbSet<ReviewVideo> ReviewVideos { get; private set; }
        public DbSet<FAQVideo> FAQVideos { get; private set; }
        public DbSet<FAQText> FAQTexts { get; private set; }
        public DbSet<Video> Videos { get; private set; }
        public DbSet<Blog> Blogs { get; private set; }
        public DbSet<KeyValue> KeyValues { get; private set; }
        public DbSet<Category> Categories { get; private set; }
        public DbSet<Author> Authors { get; private set; }
    }
}
