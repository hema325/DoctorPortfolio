using System.ComponentModel.DataAnnotations;

namespace Ibrahim.DoctorPortfolio.Dtos.Review.Text
{
    public class CreateOrUpdateReviewTextDto
    {
        public string ReviewerNameAr { get; set; }
        public string ReviewerNameEn { get; set; }
        public string ReviewAr { get; set; }
        public string ReviewEn { get; set; }
        public string SubReviewAr { get; set; }
        public string SubReviewEn { get; set; }

        [Range(1, 5)]
        public int Stars { get; set; }
    }
}
