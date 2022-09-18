using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technology.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyEntityRepository _technologyEntityRepository;

        public TechnologyBusinessRules(ITechnologyEntityRepository technologyEntityRepository)
        {
            _technologyEntityRepository = technologyEntityRepository;
        }

        public async Task TechnologyCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<TechnologyEntity> result = await _technologyEntityRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Tech exists.");
        }

        public async Task TechnologyShouldBeExistWhenRequested(TechnologyEntity technologyEntity)
        {
            if (technologyEntity == null) throw new NotFoundException("Requested Tech does not found");
        }
    }
}
