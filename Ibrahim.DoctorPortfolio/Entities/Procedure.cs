namespace Ibrahim.DoctorPortfolio.Entities
{
    public class Procedure : BaseEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string ImageUrl { get; set; }
        public string IconUrl { get; set; }
        public int? ReviewId { get; set; }

        public ICollection<Section> Sections { get; set; }
        public ReviewText Review { get; set; }    
        public ICollection<BeforeAfterImage> BeforeAfterImages { get; set; }
    }
}
