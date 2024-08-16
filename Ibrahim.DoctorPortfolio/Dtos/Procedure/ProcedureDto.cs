using Ibrahim.DoctorPortfolio.Dtos.Review.Text;

namespace Ibrahim.DoctorPortfolio.Dtos.Category
{
    public class ProcedureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string IconUrl { get; set; }

        public ICollection<SectionDto> Sections { get; set; }
        public ReviewTextDto Review { get; set; }
    }
}
