using System.ComponentModel.DataAnnotations;

namespace Ibrahim.DoctorPortfolio.Dtos.FAQ.Video
{
    public class CreateFAQVideoDto
    {
        [Url]
        public string PosterUrl { get; set; }

        [Url]
        public string VideoUrl { get; set; }
    }
}
