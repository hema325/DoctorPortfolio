namespace Ibrahim.DoctorPortfolio.Dtos.Blog
{
    public class BlogFilterDto: PaginationFilterDto
    {
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }

    }
}
