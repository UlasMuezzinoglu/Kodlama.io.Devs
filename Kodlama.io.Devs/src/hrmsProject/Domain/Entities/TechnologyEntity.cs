using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TechnologyEntity : Entity
    {
        public string Name { get; set; }

        public int ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguageEntity? ProgrammingLanguage { get; set; }

        public TechnologyEntity()
        {

        }

        public TechnologyEntity(int id, int languageId ,string name) : this()
        {
            Id = id;
            ProgrammingLanguageId = languageId;
            Name = name;
        }
    }
}
