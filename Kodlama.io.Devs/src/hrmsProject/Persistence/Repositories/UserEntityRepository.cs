using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserEntityRepository : EfRepositoryBase<User, BaseDbContext>, IUserEntityRepository
    {
        public UserEntityRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
