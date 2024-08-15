namespace Ibrahim.DoctorPortfolio.Entities
{
    public class Section : BaseEntity
    {
        public string HeaderAr { get; set; }
        public string HeaderEn { get; set; }
        public string BodyAr { get; set; }
        public string BodyEn { get; set; }

        public int CategoryId { get; set; }
    }
}
