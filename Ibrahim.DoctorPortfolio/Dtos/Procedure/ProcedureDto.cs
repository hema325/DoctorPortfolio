using Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Image;
using Ibrahim.DoctorPortfolio.Dtos.Review.Text;
using Ibrahim.DoctorPortfolio.Entities;

namespace Ibrahim.DoctorPortfolio.Dtos.Category
{
    public class ProcedureDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string ImageUrl { get; set; }
        public string IconUrl { get; set; }

        public ICollection<SectionDto> Sections { get; set; }
        public ReviewTextDto Review { get; set; }
    }
}
