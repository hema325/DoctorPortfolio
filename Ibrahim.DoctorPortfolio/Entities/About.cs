namespace Ibrahim.DoctorPortfolio.Entities
{
    public class About
    {
        public FirstSection FirstSection { get; set; }
        public SecondSection SecondSection { get; set; }
        public ThirdSection ThirdSection { get; set; }
        public FourthSection FourthSection { get; set; }
    }

    public class FirstSection
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string QuoteAr { get; set; }
        public string QuoteEn { get; set; }
        public string BioAr { get; set; }
        public string BioEn { get; set; }
        public string ImageUrl { get; set; }
    }

    public class SecondSection
    {
        public string HeaderAr { get; set; }
        public string HeaderEn { get; set; }
        public string BodyAr { get; set; }
        public string BodyEn { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ThirdSection
    {
        public string HeaderAr { get; set; }
        public string HeaderEn { get; set; }
        public string BodyAr { get; set; }
        public string BodyEn { get; set; }
        public string ImageUrl { get; set; }
    }

    public class FourthSection
    {
        public string HeaderAr { get; set; }
        public string HeaderEn { get; set; }
        public string BodyAr { get; set; }
        public string BodyEn { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
