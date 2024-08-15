using System.ComponentModel.DataAnnotations;

namespace Ibrahim.DoctorPortfolio.Dtos.Category
{
    public class CreateOrUpdateProcedureDto
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Url]
        public string IconUrl { get; set; }

        public int? ReviewId { get; set; }
        public ICollection<CreateSectionDto> Sections { get; set; }
    }
}
