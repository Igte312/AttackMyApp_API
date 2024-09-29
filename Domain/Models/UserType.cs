using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Models
{
    [Table("SIEGFRIED_TYPE")]
    public class UserType
    {
        [Key]
        public Guid SiegfriedTypeId { get; set; } = Guid.NewGuid();

        [Required]
        public string SiegfriedType { get; set; }
    }
}
