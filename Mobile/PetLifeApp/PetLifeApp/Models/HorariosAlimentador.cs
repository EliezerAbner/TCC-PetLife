using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    class HorariosAlimentador
    {
        public int HorariosAlimentadorId { get; set; }
        public string AlimentadorId { get; set; }
        public TimeSpan Horario { get; set; }
        public decimal QtdeDespejarAgua { get; set; }
        public decimal QtdeDespejarRacao { get; set; }

    }
}
