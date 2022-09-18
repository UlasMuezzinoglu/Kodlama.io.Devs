using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.programmingLanguage.Rules
{
    public class ProgrammingRulesBusinessRules
    {
        private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;

        public ProgrammingRulesBusinessRules(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository)
        {
            _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
        }

        public async Task ProgrammingLanguageCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguageEntity> result = await _programmingLanguageEntityRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language exists.");
        }
    }
}
