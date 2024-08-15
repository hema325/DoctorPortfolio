
namespace Ibrahim.DoctorPortfolio.Entities
{
    public class BeforeAfterVideo: BaseEntity
    {
        public string PosterUrl { get; set; }
        public string VideoUrl { get; set; }

        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }
    }
}
