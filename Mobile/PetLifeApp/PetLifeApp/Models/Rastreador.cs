﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    class Rastreador
    {
        public int RastreadorId { get; set; }
        public int ClienteId { get; set; }
        public int PetId { get; set; }
        public string Identificador { get; set; }
        public string NomeRastreador { get; set; }
    }
}
