using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoteriaMexicana.Models
{
    public class OpcionesVictoria
    {
        public bool Horizontal { get; set; }
        public bool Vertical { get; set; }
        public bool Diagonal { get; set; }
        public bool Lleno { get; set; }
        public bool Personalizado { get; set; }
        public bool[,] PatronPersonalizado { get; set; }
    }
}
