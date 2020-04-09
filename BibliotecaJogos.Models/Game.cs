using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.Models
{
    public class Game
    {
        public int Id_Game { get; set; }
        public string Title { get; set; }
        public string Cover_Image { get; set; }
        public double? Amount_Paid { get; set; }
        public DateTime? Purchase_Date { get; set; }
        public int Id_Publisher { get; set; }
        public int Id_Genre { get; set; }

    }
}

