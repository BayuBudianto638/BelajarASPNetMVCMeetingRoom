using Mvc.JQuery.DataTables;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelajarASPNetMVC.Models.Users
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [DisplayName("User Name")]
        [DataTables(Width = "100px")]
        public string userName { get; set; }
        [DisplayName("Name")]
        [DataTables(Width = "100px")]
        public string surName { get; set; }
        [DisplayName("Last Name")]
        [DataTables(Width = "100px")]
        public string lastName { get; set; }
        [DisplayName("Email Name")]
        [DataTables(Width = "100px")]
        public string Email { get; set; }
        [DisplayName("No. HP")]
        [DataTables(Width = "100px")]
        public int NoHP { get; set; }
        [DisplayName("Password")]
        [DataTables(Width = "100px")]
        public string Password { get; set; }
        public Nullable<byte> IsAdmin { get; set; }
    }
}
