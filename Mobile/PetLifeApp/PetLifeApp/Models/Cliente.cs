using MySqlConnector;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PetLifeApp.Models
{
    class Cliente
    {
        private int id;
        private string dataNascimento;
        public string DataNascimento
        {
            get { return dataNascimento; }

            set {  dataNascimento = ConversorDatas(value);}
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        private string ConversorDatas(string valorAntigo)
        {
            DateTime dataAntiga = Convert.ToDateTime(valorAntigo);
            string dataConvertida = dataAntiga.ToString("yyyy-MM-dd HH:mm:ss");

            return dataConvertida;
        }  
    }
}
