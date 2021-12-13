using System.Threading.Tasks;
using UaConnects.Domain.Entities;

namespace UaConnects.Domain.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
