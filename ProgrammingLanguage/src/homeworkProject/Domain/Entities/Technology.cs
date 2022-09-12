using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public Technology()
        {
        }

        public Technology(string name, int programmingLanguageId, string description, bool ısOpenSource, ProgrammingLanguage programmingLanguage) : this()
        {
            Name = name;
            ProgrammingLanguageId = programmingLanguageId;
            Description = description;
            IsOpenSource = ısOpenSource;
            ProgrammingLanguage = programmingLanguage;
        }

        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Description { get; set; }
        public bool IsOpenSource { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
