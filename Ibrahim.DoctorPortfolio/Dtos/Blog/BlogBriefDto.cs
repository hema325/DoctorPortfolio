namespace Ibrahim.DoctorPortfolio.Dtos.Blog
{
    public class BlogBriefDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string WriterName { get; set; }
        public DateTime WrittenOn { get; set; }
    }
}
