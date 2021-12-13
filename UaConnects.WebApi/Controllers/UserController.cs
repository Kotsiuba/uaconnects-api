using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UaConnects.Domain.Entities;
using UaConnects.Domain.Services.Interfaces;
using UaConnects.WebApi.ViewModels.Users;

namespace UaConnects.WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<Guid> RegisterUserAsync([FromBody] RegisterUserModel registerUserModel)
        {
            _logger.LogDebug("Register user endpoint called");

            var user = new User
            {
                FirstName = registerUserModel.FirstName,
                LastName = registerUserModel.LastName,
                EmailAddress = registerUserModel.EmailAddress,
                MobilePhone = registerUserModel.MobilePhone
            };

            var userId = await _userService.RegisterUserAsync(user);

            _logger.LogDebug("Register user executed successfully");

            return userId;
        }

        [HttpGet]
        public async Task<User> GetUserAsync([FromQuery] Guid userId)
        {
            _logger.LogDebug("Get user endpoint called");



            var user = await _userService.GetUserAsync(userId);

            _logger.LogDebug("Get user executed successfully");

            return user;
        }
    }
}
