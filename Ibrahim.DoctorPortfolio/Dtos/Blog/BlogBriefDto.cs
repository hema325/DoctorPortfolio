namespace Ibrahim.DoctorPortfolio.Dtos.Blog
{
    public class BlogBriefDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string WriterNameAr { get; set; }
        public string WriterNameEn { get; set; }
        public DateTime WrittenOn { get; set; }
    }
}
