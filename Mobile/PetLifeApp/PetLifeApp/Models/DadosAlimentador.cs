using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    class DadosAlimentador
    {
        private string dataRecolhida;
        public string DataRecolhida
        {
            get { return dataRecolhida; }
            set { dataRecolhida = ConversorDatas(value); }
        }
        public int DadosAlimentadorId { get; set; }
        public decimal QtdeConsumidaAgua { get; set; }
        public decimal QtdeConsumidaRacao { get; set; }

        private string ConversorDatas(string valorAntigo)
        {
            DateTime dataAntiga = Convert.ToDateTime(valorAntigo);
            string dataConvertida = dataAntiga.ToString("yyyy-MM-dd HH:mm:ss");

            return dataConvertida;
        }
    }
}
