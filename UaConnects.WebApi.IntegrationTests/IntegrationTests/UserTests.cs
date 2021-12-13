using FakeItEasy;
using Microsoft.Extensions.Logging;
using UaConnects.Domain.Services.Interfaces;
using UaConnects.WebApi.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;
using UaConnects.WebApi.ViewModels.Users;
using FluentAssertions;
using System;
using UaConnects.Domain.Exceptions;

namespace UaConnects.WebApi.IntegrationTests.IntegrationTests
{
    public class UserTests : TestBase
    {
        private readonly SystemUnderTest _systemUnderTest;

        public UserTests()
        {
            _systemUnderTest = new SystemUnderTest
            {
                Users = new UserController(
                    ServiceProvider.GetRequiredService<IUserService>(),
                    A.Fake<ILogger<UserController>>())
            };
        }

        [Fact]
        public async Task ShouldCreateUser_WhenUserRegistered()
        {
            var userModel = new RegisterUserModel
            {
                FirstName = "Bob",
                LastName = "Marley",
                EmailAddress = "bob.marley@gmail.com",
                MobilePhone = "380112233444"
            };

            var createdUserId = await _systemUnderTest.Users.RegisterUserAsync(userModel);

            var createdUser = await _systemUnderTest.Users.GetUserAsync(createdUserId);

            createdUser.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldNotCreateUser_WhenRegistered2Times()
        {
            var userModel = new RegisterUserModel
            {
                FirstName = "Bob",
                LastName = "Marley",
                EmailAddress = "bob.marley@gmail.com",
                MobilePhone = "380112233444"
            };

            var createdUserId = await _systemUnderTest.Users.RegisterUserAsync(userModel);

            Func<Task> act = () => _systemUnderTest.Users.RegisterUserAsync(userModel); ;

            await act.Should().ThrowAsync<UserAlreadyRegisteredException>()
                .WithMessage("User bob.marley@gmail.com has been already registered!");

            var createdUser = await _systemUnderTest.Users.GetUserAsync(createdUserId);

            createdUser.ExistsLoginAttemps.Should().BeTrue();
        }
    }
}
