using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProgrammingLanguage : Entity
{
    public ProgrammingLanguage()
    {

    }
    public ProgrammingLanguage(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public string Name { get; set; }
}
