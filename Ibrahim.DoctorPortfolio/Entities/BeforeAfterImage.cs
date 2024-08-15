using Ibrahim.DoctorPortfolio.Enums;

namespace Ibrahim.DoctorPortfolio.Entities
{
    public class BeforeAfterImage: BaseEntity
    {
        public ImageTypes ImageType { get; set; }
        public string ImageUrl { get; set; }

        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }
    }
}
