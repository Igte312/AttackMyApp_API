using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("SIGRID_USER")]
    public class Users
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateDate { get; set; }

        public Guid? LastUpdateId { get; set; } = Guid.NewGuid();

    }
}
