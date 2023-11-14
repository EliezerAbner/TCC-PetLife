using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    public class Pet
    {
        private string dataNascimento;
        public string DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = ConversorDatas(value); }
        }
        public int PetId { get; set; }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public decimal Peso { get; set; }
        public string Porte { get; set; }
        public string Raca { get; set; }
        public string Observacao { get; set; }

        private string ConversorDatas(string valorAntigo)
        {
            DateTime dataAntiga = Convert.ToDateTime(valorAntigo);
            string dataConvertida = dataAntiga.ToString("yyyy-MM-dd HH:mm:ss");

            return dataConvertida;
        }      
    }
}
