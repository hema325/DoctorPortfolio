using Ibrahim.DoctorPortfolio.Enums;

namespace Ibrahim.DoctorPortfolio.Entities
{
    public class Video: BaseEntity
    {
        public string PosterUrl { get; set; }
        public string VideoUrl { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string SubTitleAr { get; set; }
        public string SubTitleEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public VideoTypes Type { get; set; }
    }
}
