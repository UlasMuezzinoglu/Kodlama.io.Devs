using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.programmingLanguage.Queries.GetProgrammingLanguageById
{
    public class GetProgrammingLanguageByIdQuery: IRequest<GetProgrammingLanguageByIdDto>
    {
        public int Id { get; set; }
        public class GetProgrammingLanguageByIdHandler : IRequestHandler<GetProgrammingLanguageByIdQuery, GetProgrammingLanguageByIdDto>
        {
            private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingRulesBusinessRules _programmingRulesBusinessRules;

            public GetProgrammingLanguageByIdHandler(IMapper mapper, IProgrammingLanguageEntityRepository programmingLanguageRepository, ProgrammingRulesBusinessRules programmingLanguageBusinessRules)
            {
                _mapper = mapper;
                _programmingLanguageEntityRepository = programmingLanguageRepository;
                _programmingRulesBusinessRules = programmingLanguageBusinessRules;
            }
            public async Task<GetProgrammingLanguageByIdDto> Handle(GetProgrammingLanguageByIdQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageEntity? programmingLanguage = await _programmingLanguageEntityRepository.GetAsync(c => c.Id == request.Id);
                await _programmingRulesBusinessRules.ProgrammingLanguageShouldBeExistWhenRequested(programmingLanguage);
                GetProgrammingLanguageByIdDto programmingLanguageGetByIdDto = _mapper.Map<GetProgrammingLanguageByIdDto>(programmingLanguage);
                return programmingLanguageGetByIdDto;
            }
        }
    }
}
