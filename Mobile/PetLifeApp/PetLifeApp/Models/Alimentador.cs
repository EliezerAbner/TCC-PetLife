using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    class Alimentador
    {
        public int AlimentadorId { get; set; }
        public int ClienteId { get; set; }
        public string Identificador { get; set; } 
        public string NomeAlimentador { get; set; }
    }
}
