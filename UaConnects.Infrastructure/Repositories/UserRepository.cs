using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UaConnects.Domain.Entities;
using UaConnects.Domain.Repository.Interfaces;
using UaConnects.Infrastructure.DataAccess;

namespace UaConnects.Infrastructure.Repositories
{
    class UserRepository : EfCoreGenericRepository<User>, IUserRepository
    {
        public UserRepository(UaConnectsContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(user => user.EmailAddress == email);
        }
    }
}
