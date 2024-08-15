using Ibrahim.DoctorPortfolio.Dtos.Category;

namespace Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Video
{
    public class BeforeAfterVideoDto
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string VideoUrl { get; set; }
        public ProcedureBriefDto Procedure { get; set; }
    }
}
