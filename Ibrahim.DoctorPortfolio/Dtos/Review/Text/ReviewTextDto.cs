namespace Ibrahim.DoctorPortfolio.Dtos.Review.Text
{
    public class ReviewTextDto
    {
        public int Id { get; set; }
        public string ReviewerNameAr { get; set; }
        public string ReviewerNameEn { get; set; }
        public string ReviewAr { get; set; }
        public string ReviewEn { get; set; }
        public string SubReviewAr { get; set; }
        public string SubReviewEn { get; set; }
        public int Stars { get; set; }
    }
}
