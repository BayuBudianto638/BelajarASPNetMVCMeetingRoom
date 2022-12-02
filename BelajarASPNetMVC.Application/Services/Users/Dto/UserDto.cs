using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.Users.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string surName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public int NoHP { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime LastChangePassword { get; set; }
        public Nullable<byte> IsAdmin { get; set; }
    }
}
