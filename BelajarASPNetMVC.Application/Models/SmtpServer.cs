using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Models
{
    public class SmtpServer
    {
        public string username { get; set; }
        public string password { get; set; }
        public string server { get; set; }
        public int port { get; set; }
        public string mailSender { get; set; }
    }
}
