

using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProgrammingLanguageEntityRepository : EfRepositoryBase<ProgrammingLanguageEntity, BaseDbContext>, IProgrammingLanguageEntityRepository
    {
        public ProgrammingLanguageEntityRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
