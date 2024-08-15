using Ibrahim.DoctorPortfolio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ibrahim.DoctorPortfolio.Data.Configurations
{
    public class VideosConfig : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasIndex(v => v.Type);
        }
    }
}
