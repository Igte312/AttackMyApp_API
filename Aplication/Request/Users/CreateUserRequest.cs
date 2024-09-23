using System.ComponentModel.DataAnnotations;

namespace Aplication.Request.Users
{
    public class CreateUserRequest
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
