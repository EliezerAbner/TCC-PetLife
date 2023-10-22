using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    class DadosRastreador
    {
        public int DadosRastreadorId { get; set; }
        private string dataRecolhida;
        public string DataRecolhida 
        { 
            get {  return dataRecolhida; }
            set { dataRecolhida = ConversorDatas(value);}
        }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        private string ConversorDatas(string valorAntigo)
        {
            DateTime dataAntiga = Convert.ToDateTime(valorAntigo);
            string dataConvertida = dataAntiga.ToString("yyyy-MM-dd HH:mm:ss");

            return dataConvertida;
        }
    }
}
