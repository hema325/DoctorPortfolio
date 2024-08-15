using Ibrahim.DoctorPortfolio.Enums;

namespace Ibrahim.DoctorPortfolio.Entities
{
    public class FAQText: BaseEntity
    {
        public string QuestionAr { get; set; }
        public string QuestionEn { get; set; }
        public string AnswerAr { get; set; }
        public string AnswerEn { get;set; }

        public QuestionTypes Type { get; set; }
    }
}
