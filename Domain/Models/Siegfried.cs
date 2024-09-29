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
        [ForeignKey("Users")]
        public Guid UserId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateDate { get; set; }

        public Guid? LastUpdateId { get; set; } = Guid.NewGuid();

        public Users User { get; set; }
    }
    
}
