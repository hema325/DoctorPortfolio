using Ibrahim.DoctorPortfolio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ibrahim.DoctorPortfolio.Dtos.Video
{
    public class CreateOrUpdateVideoDto
    {
        [Url]
        public string PosterUrl { get; set; }

        [Url]
        public string VideoUrl { get; set; }

        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string SubTitleAr { get; set; }
        public string SubTitleEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }

        [EnumDataType(typeof(VideoTypes))]
        public string Type { get; set; }
    }
}
