using Ibrahim.DoctorPortfolio.Enums;

namespace Ibrahim.DoctorPortfolio.Entities
{
    public class ReviewText: BaseEntity
    {
        public string ReviewerNameAr { get; set; }
        public string ReviewerNameEn { get; set; }
        public string ReviewAr { get; set; }
        public string ReviewEn { get; set; }
        public string SubReviewAr { get; set; }
        public string SubReviewEn { get; set; }
        public int Stars { get; set; }
    }
}
