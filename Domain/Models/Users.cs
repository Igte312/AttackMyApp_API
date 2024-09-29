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
        [Column(TypeName = "timestamp")]
        public DateTime CreationDate { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? UpdateDate { get; set; }

        public Guid? LastUpdateId { get; set; }


        [Required]
        [ForeignKey("SiegfriedID")]
        public Guid SiegfriedID { get; set; }

        public Siegfried Siegfried { get; set; }

    }
}
