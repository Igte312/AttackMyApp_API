using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Request.Users
{
    public class CreateUserTypeRequest
    {
        [Required]
        public string SiegfriedType { get; set; }
    }
}
