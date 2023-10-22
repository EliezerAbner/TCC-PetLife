using MySqlConnector;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PetLifeApp.Models
{
    class Cliente
    {
        private int id;
        private string senha;
        private string dataNascimento;
        public string Senha 
        { 
            get { return senha; } 
            
            set { senha = Encode(value); } 
        }

        public string DataNascimento
        {
            get { return dataNascimento; }

            set {  dataNascimento = ConversorDatas(value);}
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email {  get; set; }
        public string Telefone { get; set; }

        private static string Encode(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string ConversorDatas(string valorAntigo)
        {
            DateTime dataAntiga = Convert.ToDateTime(valorAntigo);
            string dataConvertida = dataAntiga.ToString("yyyy-MM-dd HH:mm:ss");

            return dataConvertida;
        }  
    }
}
