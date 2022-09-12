namespace Application.Features.Technologies.Dtos
{
    public class CreatedTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Description { get; set; }
        public bool IsOpenSource { get; set; }
    }
}
