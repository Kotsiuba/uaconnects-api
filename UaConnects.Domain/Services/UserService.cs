using System;
using System.Threading.Tasks;
using UaConnects.Domain.Entities;
using UaConnects.Domain.Exceptions;
using UaConnects.Domain.Repository.Interfaces;
using UaConnects.Domain.Services.Interfaces;

namespace UaConnects.Domain.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _userRepository.FindByIdAsync(userId);
        }

        public async Task<Guid> RegisterUserAsync(User user)
        {
            await CheckUserForBeingAlreadyRegisteredAndThrow(user);

            user.RegistrationTime = DateTime.Now;

            await _userRepository.InsertOneAsync(user);

            return user.Id;
        }

        private async Task CheckUserForBeingAlreadyRegisteredAndThrow(User user)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(user.EmailAddress);

            if (existingUser != null)
            {
                existingUser.LastLoginAttempt = DateTime.Now;

                await _userRepository.UpdateAsync(user);

                throw new UserAlreadyRegisteredException(user.EmailAddress);
            }
        }
    }
}
