using System.ComponentModel.DataAnnotations;

namespace Aplication.Request.Users
{
    public class CreateUserTypeRequest
    {
        [Required]
        public string SiegfriedType { get; set; }
    }
}
