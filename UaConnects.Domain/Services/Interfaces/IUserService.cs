using System;
using System.Threading.Tasks;
using UaConnects.Domain.Entities;

namespace UaConnects.Domain.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> RegisterUserAsync(User user);
        public Task<User> GetUserAsync(Guid userId);
    }
}
