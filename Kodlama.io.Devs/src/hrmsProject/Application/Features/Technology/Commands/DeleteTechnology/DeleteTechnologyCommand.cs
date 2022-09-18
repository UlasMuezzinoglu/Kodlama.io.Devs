using Application.Features.programmingLanguage.Commands.DeleteProgrammingLanguage;
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

namespace Application.Features.Technology.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyLanguageCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyEntityRepository _technologyEntityRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyLanguageCommandHandler(ITechnologyEntityRepository technologyEntityRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyEntityRepository = technologyEntityRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                TechnologyEntity technologyEntity = await _technologyEntityRepository.GetAsync(p => p.Id == request.Id);

                await _technologyBusinessRules.TechnologyShouldBeExistWhenRequested(technologyEntity);

                TechnologyEntity deletedTechnologyEntity = await _technologyEntityRepository.DeleteAsync(technologyEntity);

                return _mapper.Map<DeletedTechnologyDto>(deletedTechnologyEntity);

            }
        }
    }
}
