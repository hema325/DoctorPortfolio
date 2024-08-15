using Ibrahim.DoctorPortfolio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ibrahim.DoctorPortfolio.Dtos.FAQ.Text
{
    public class CreateOrUpdateFAQTextDto
    {
        public string QuestionAr { get; set; }
        public string QuestionEn { get; set; }
        public string AnswerAr { get; set; }
        public string AnswerEn { get; set; }

        [EnumDataType(typeof(QuestionTypes))]
        public string Type { get; set; }
    }
}
