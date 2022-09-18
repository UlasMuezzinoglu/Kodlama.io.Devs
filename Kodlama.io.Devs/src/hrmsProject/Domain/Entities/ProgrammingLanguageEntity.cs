using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguageEntity : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<TechnologyEntity> Technologies { get; set; }

        public ProgrammingLanguageEntity()
        {

        }

        public ProgrammingLanguageEntity(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
