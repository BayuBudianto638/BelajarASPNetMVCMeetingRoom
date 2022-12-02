using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Data.Databases
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string userName { get; set; }
        public string surName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public int NoHP { get; set; }
        public string Password { get; set; }
        public string passwordSalt { get; set; }
        public Nullable<System.DateTime> lastChangePassword { get; set; }
        public Nullable<byte> IsAdmin { get; set; }
    }
}
