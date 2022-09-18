using Application.Features.programmingLanguage.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.programmingLanguage.Models
{
    public class ProgrammingLanguageListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> Items { get; set; }
    }
}
