using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Rules;
using Application.Features.Technology.Commands.DeleteTechnology;
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

namespace Application.Features.Technology.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyEntityRepository _technologyEntityRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(ITechnologyEntityRepository technologyEntityRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyEntityRepository = technologyEntityRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {

                await _technologyBusinessRules.TechnologyCanNotBeDuplicatedWhenInserted(request.Name);

                TechnologyEntity? technologyEntity = await _technologyEntityRepository.GetAsync(l => l.Id == request.Id);

                _mapper.Map(request, technologyEntity);

                TechnologyEntity updatedTechnologyEntity = await _technologyEntityRepository.UpdateAsync(technologyEntity);
                UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnologyEntity);

                return updatedTechnologyDto;

            }
        }
    }
}
