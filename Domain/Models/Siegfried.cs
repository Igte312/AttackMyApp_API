using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{

    [Table("SIEGFRIED")]
    public class Siegfried
    {
        [Key]
        public Guid SiegfriedID { get; set; } = Guid.NewGuid();

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        public DateTime CreationDate { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? UpdateDate { get; set; }

        public Guid? LastUpdateId { get; set; }

        [ForeignKey(nameof(UserType))]
        public Guid SiegfriedTypeId { get; set; }

        public UserType UserType { get; set; }

        public Users Users { get; set; }

    }
    
}
