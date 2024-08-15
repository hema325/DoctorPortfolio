namespace Ibrahim.DoctorPortfolio.Entities
{
    public class Shared
    {
        public ContactInfo ContactInfo { get; set; }
        public SocialLinks SocialLinks { get; set; }
    }

    public class ContactInfo
    {
        public string Email { get; set; }
        public string AddressAr { get; set; }
        public string AddressEn { get; set; }
        public string Phone { get; set; }
    }

    public class SocialLinks
    {
        public string OnlyFans { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Tiktok { get; set; }
    }
}
