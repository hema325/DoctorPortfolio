using Ibrahim.DoctorPortfolio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ibrahim.DoctorPortfolio.Data.Configurations
{
    public class FAQTextConfig : IEntityTypeConfiguration<FAQText>
    {
        public void Configure(EntityTypeBuilder<FAQText> builder)
        {
            builder.HasIndex(faq => faq.Type);
        }
    }
}
