using Application.Features.programmingLanguage.Commands.DeleteProgrammingLanguage;
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

namespace Application.Features.programmingLanguage.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingRulesBusinessRules _programmingRulesBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository, IMapper mapper, ProgrammingRulesBusinessRules programmingRulesBusinessRules)
            {
                _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
                _mapper = mapper;
                _programmingRulesBusinessRules = programmingRulesBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingRulesBusinessRules.ProgrammingLanguageCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguageEntity? language = await _programmingLanguageEntityRepository.GetAsync(l => l.Id == request.Id);

                _mapper.Map(request, language);

                ProgrammingLanguageEntity updatedLanguage = await _programmingLanguageEntityRepository.UpdateAsync(language);
                UpdatedProgrammingLanguageDto updatedLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedLanguage);

                return updatedLanguageDto;

            }
        }

    }
}
