using Application.Features.programmingLanguage.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Dtos
{
    public class CreatedLanguageTechnologyDto
    {
        public int Id { get; set; }
        public GetProgrammingLanguageByIdDto programmingLanguage { get; set; }
        public string Name { get; set; }


    }
}
