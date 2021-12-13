using System;

namespace UaConnects.Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }

        public DateTime? RegistrationTime { get; set; }
        public DateTime? LastLoginAttempt { get; set; } = null;

        public bool ExistsLoginAttemps => LastLoginAttempt != null;
    }
}
