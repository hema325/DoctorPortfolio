namespace Ibrahim.DoctorPortfolio.Dtos.About
{
    public class AboutDto
    {
        public FirstSectionDto FirstSection { get; set; }
        public SecondSectionDto SecondSection { get; set; }
        public ThirdSectionDto ThirdSection { get; set; }
        public FourthSectionDto FourthSection { get; set; }
    }

    public class FirstSectionDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Quote { get; set; }
        public string Bio { get; set; }
    }

    public class SecondSectionDto
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ThirdSectionDto
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
    }

    public class FourthSectionDto
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
