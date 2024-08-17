namespace Ibrahim.DoctorPortfolio.Entities
{
    public class Blog: BaseEntity
    {
        public string ImageUrl { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public DateTime WrittenOn { get; set; }
        public string ContentAr { get; set; }
        public string ContentEn { get; set; }
        public string? RecommendedVideoUrl { get; set; }
        public int? AuthorId { get; set; }

        public ICollection<Category> Categories { get; set; }
        public Author? Author { get; set; }
    }
}
