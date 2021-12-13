using System.ComponentModel.DataAnnotations;

namespace UaConnects.WebApi.ViewModels.Users
{
    public class RegisterUserModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [Phone]
        public string MobilePhone { get; set; }
    }
}
