using System;

namespace UaConnects.Domain.Exceptions
{
    public class UserAlreadyRegisteredException : Exception
    {
        public UserAlreadyRegisteredException(string userEmail) : base($"User {userEmail} has been already registered!")
        {
        }
    }
}
