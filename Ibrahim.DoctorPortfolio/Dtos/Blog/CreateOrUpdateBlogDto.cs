namespace Ibrahim.DoctorPortfolio.Dtos.Blog
{
    public class CreateOrUpdateBlogDto
    {
        public string ImageUrl { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string WriterNameAr { get; set; }
        public string WriterNameEn { get; set; }
        public DateTime WrittenOn { get; set; }
        public string ContentAr { get; set; }
        public string ContentEn { get; set; }
        public string? RecommendedVideoUrl { get; set; }
        public int? AuthorId { get; set; }

        public ICollection<int> CategoryIds { get; set; }
    }
}
