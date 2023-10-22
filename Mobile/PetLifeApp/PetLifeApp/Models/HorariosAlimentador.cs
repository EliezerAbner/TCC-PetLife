using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    class HorariosAlimentador
    {
        public int HorariosAlimentadorId { get; set; }
        private string horario;
        public string Horario 
        { 
            get { return horario; }
            set { horario = ConversorDatas(value); }
        }
        public decimal QtdeDespejar { get; set; }

        private string ConversorDatas(string valorAntigo)
        {
            DateTime dataAntiga = Convert.ToDateTime(valorAntigo);
            string dataConvertida = dataAntiga.ToString("yyyy-MM-dd HH:mm:ss");

            return dataConvertida;
        }
    }
}
