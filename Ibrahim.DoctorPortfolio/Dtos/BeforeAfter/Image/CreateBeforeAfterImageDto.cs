using Ibrahim.DoctorPortfolio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Image
{
    public class CreateBeforeAfterImageDto
    {
        [EnumDataType(typeof(ImageTypes))]
        public string ImageType { get; set; }

        [Url]
        public string ImageUrl { get; set; }
        public int ProcedureId { get; set; }
    }
}
