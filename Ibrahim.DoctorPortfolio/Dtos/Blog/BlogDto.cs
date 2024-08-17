using Ibrahim.DoctorPortfolio.Dtos.Author;
using Ibrahim.DoctorPortfolio.Dtos.Category;

namespace Ibrahim.DoctorPortfolio.Dtos.Blog
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime WrittenOn { get; set; }
        public string Content { get; set; }
        public string? RecommendedVideoUrl { get; set; }
        public AuthorDto Author { get; set; }

        public ICollection<CategoryDto> Categories { get; set; }
    }
}
