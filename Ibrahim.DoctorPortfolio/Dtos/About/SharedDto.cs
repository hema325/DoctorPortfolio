namespace Ibrahim.DoctorPortfolio.Dtos.About
{
    public class SharedDto
    {
        public ContactInfoDto ContactInfo { get; set; }
        public SocialLinksDto SocialLinks { get; set; }
    }

    public class ContactInfoDto
    {
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class SocialLinksDto
    {
        public string OnlyFans { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Tiktok { get; set; }
    }
}
