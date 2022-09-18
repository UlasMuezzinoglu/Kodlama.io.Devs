using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.programmingLanguage.addProgrammingLanguage
{
    public partial class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingRulesBusinessRules _programmingRulesBusinessRules;

            public CreateBrandCommandHandler(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository, IMapper mapper, ProgrammingRulesBusinessRules programmingRulesBusinessRules)
            {
                _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
                _mapper = mapper;
                _programmingRulesBusinessRules = programmingRulesBusinessRules;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingRulesBusinessRules.ProgrammingLanguageCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguageEntity mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguageEntity>(request);
                ProgrammingLanguageEntity createdProgrammingLanguage = await _programmingLanguageEntityRepository.AddAsync(mappedProgrammingLanguage);
                CreatedProgrammingLanguageDto createdBrandDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);

                return createdBrandDto;
            }
        }
    }
}
