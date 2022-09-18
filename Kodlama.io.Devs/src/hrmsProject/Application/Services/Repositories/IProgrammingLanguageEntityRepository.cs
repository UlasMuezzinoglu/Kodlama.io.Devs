using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IProgrammingLanguageEntityRepository : IAsyncRepository<ProgrammingLanguageEntity>, IRepository<ProgrammingLanguageEntity>
    {
    }
}
