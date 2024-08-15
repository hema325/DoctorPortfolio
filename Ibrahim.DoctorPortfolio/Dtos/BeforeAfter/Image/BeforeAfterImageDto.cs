using Ibrahim.DoctorPortfolio.Dtos.Category;

namespace Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Image
{
    public class BeforeAfterImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ImageType { get; set; }
        public ProcedureBriefDto Procedure { get; set; }
    }
}
