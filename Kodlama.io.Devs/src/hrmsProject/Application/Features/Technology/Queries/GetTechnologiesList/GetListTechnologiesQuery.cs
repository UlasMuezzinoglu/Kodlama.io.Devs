using Application.Features.Technology.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Queries.GetTechnologiesList
{
    public class GetListTechnologiesQuery : IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologiesQuery, TechnologyListModel>
        {

            private readonly IMapper _mapper;
            private readonly ITechnologyEntityRepository _technologyEntityRepository;

            public GetListTechnologyQueryHandler(IMapper mapper, ITechnologyEntityRepository technologyEntityRepository)
            {
                _mapper = mapper;
                _technologyEntityRepository = technologyEntityRepository;
            }

            async Task<TechnologyListModel> IRequestHandler<GetListTechnologiesQuery, TechnologyListModel>.Handle(GetListTechnologiesQuery request, CancellationToken cancellationToken)
            {
                //language models
                IPaginate<TechnologyEntity> techs = await _technologyEntityRepository.GetListAsync(include:
                                              m => m.Include(c => c.ProgrammingLanguage),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );
                //dataModel
                TechnologyListModel mappedModels = _mapper.Map<TechnologyListModel>(techs);
                return mappedModels;
            }
        }
    }
}
