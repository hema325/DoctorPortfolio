using System.ComponentModel.DataAnnotations;

namespace Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Video
{
    public class CreateBeforeAfterVideoDto
    {
        [Url]
        public string PosterUrl { get; set; }
        
        [Url]
        public string VideoUrl { get; set; }

        public int ProcedureId { get; set; }
    }
}
