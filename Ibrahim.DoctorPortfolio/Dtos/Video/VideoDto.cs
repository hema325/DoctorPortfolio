using Ibrahim.DoctorPortfolio.Enums;

namespace Ibrahim.DoctorPortfolio.Dtos.Video
{
    public class VideoDto
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
