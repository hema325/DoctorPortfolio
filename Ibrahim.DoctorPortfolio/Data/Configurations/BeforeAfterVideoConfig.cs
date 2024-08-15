using Ibrahim.DoctorPortfolio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ibrahim.DoctorPortfolio.Data.Configurations
{
    public class BeforeAfterVideoConfig : IEntityTypeConfiguration<BeforeAfterVideo>
    {
        public void Configure(EntityTypeBuilder<BeforeAfterVideo> builder)
        {
            builder.HasOne(b => b.Procedure).WithMany().HasForeignKey(b => b.ProcedureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
