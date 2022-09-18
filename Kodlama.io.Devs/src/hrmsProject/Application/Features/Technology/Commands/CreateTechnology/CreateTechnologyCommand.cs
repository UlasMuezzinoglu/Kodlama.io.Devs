using Application.Features.programmingLanguage.addProgrammingLanguage;
using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Rules;
using Application.Features.Technology.Dtos;
using Application.Features.Technology.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreatedLanguageTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }



        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedLanguageTechnologyDto>
        {
            private readonly ITechnologyEntityRepository _technologyEntityRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public CreateTechnologyCommandHandler(ITechnologyEntityRepository technologyEntityRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyEntityRepository = technologyEntityRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<CreatedLanguageTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.TechnologyCanNotBeDuplicatedWhenInserted(request.Name);
                TechnologyEntity technologyEntity = _mapper.Map<TechnologyEntity>(request);

                technologyEntity = await _technologyEntityRepository.AddAsync(technologyEntity);

                return _mapper.Map<CreatedLanguageTechnologyDto>(technologyEntity);
                
            }
        }
    }
}
