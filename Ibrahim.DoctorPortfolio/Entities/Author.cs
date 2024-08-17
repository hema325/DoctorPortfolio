namespace Ibrahim.DoctorPortfolio.Entities
{
    public class Author: BaseEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
