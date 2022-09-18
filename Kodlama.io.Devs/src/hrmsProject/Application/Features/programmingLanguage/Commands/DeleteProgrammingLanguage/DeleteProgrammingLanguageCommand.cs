using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.programmingLanguage.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageEntityRepository _programmingLanguageEntityRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingRulesBusinessRules _programmingRulesBusinessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageEntityRepository programmingLanguageEntityRepository, IMapper mapper, ProgrammingRulesBusinessRules programmingRulesBusinessRules)
            {
                _programmingLanguageEntityRepository = programmingLanguageEntityRepository;
                _mapper = mapper;
                _programmingRulesBusinessRules = programmingRulesBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageEntity programmingLanguage = await _programmingLanguageEntityRepository.GetAsync(p => p.Id == request.Id);

                await _programmingRulesBusinessRules.ProgrammingLanguageShouldBeExistWhenRequested(programmingLanguage);

                ProgrammingLanguageEntity deletedProgrammingLanguage = await _programmingLanguageEntityRepository
                    .DeleteAsync(programmingLanguage);

                return _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);

            }
        }
    }
}
