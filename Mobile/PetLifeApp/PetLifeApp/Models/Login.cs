using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PetLifeApp.Models
{
    class LoginCliente
    {
        private string senha;

        public int LoginId { get; set; }
        public int EmailId { get; set; }
        public int ClienteId { get; set; }
        public string Email { get; set; }
        public string Senha
        {
            get {  return senha; }
            set { senha = Encode(value); }
        }

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
    }
}
