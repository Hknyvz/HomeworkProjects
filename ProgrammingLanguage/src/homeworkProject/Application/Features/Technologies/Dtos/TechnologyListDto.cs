using Core.Persistence.Paging;

namespace Application.Features.Technologies.Dtos;

public class TechnologyListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProgrammingLanguageName { get; set; }
    public int ProgrammingLanguageId { get; set; }
    public string Description { get; set; }
    public bool IsOpenSource { get; set; }
}
