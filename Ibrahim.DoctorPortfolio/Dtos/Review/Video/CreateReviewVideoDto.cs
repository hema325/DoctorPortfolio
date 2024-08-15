using System.ComponentModel.DataAnnotations;

namespace Ibrahim.DoctorPortfolio.Dtos.Review.Video
{
    public class CreateReviewVideoDto
    {
        [Url]
        public string VideoUrl { get; set; }
    }
}
