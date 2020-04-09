using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.Models
{
    public class User
    {
        public int Id_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public char Role { get; set; }
        public bool? Is_Locked { get; set; }
        public int? Nr_Attempts { get; set; }
        public DateTime? Locked_Date_Time { get; set; }

    }
}



