namespace Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Image
{
    public class BeforeAfterImageFilterDto: PaginationFilterDto
    {
        public string? ImageType { get; set; }
        public int? ProcedureId { get; set; }
    }
}
