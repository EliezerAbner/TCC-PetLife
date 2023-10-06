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
        public string Senha 
        { 
            get { return senha; } 
            
            set { senha = Encode(value); } 
        }

        private static string conn = @"server=35.232.102.184;port=3306;database=petlifedb;user id=tds;password=tdssabado;charset=utf8";

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string Email {  get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }

        public void NovoCliente()
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = "CALL novo_cliente('" + this.Nome + "', " + this.dataNascimento + ", '" + this.Email + "', '" + this.senha + "', '" + this.Rua + "', '" + this.Numero + "', '" + this.Cep + "', '" + this.Cidade + "', '" + this.Estado + "', '" + this.Telefone + "')";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EditarCliente()
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                ObterId(this.Nome);
                string sql = "CALL editar_cliente(" + id + " '" + this.Nome + "', " + this.dataNascimento + ", '" + this.Email + "', '" + this.senha + "', '" + this.Rua + "', '" + this.Numero + "', '" + this.Cep + "', '" + this.Cidade + "', '" + this.Estado + "', '" + this.Telefone + "')";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ExcluirCliente(int id)
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = "CALL excluir_cliente(" + id + ")";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public bool FazerLogin(Cliente cliente)
        {
            bool loginAutorizado = false;

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = "CALL login(" + ObterId(cliente.Nome) + ", '" + cliente.Email + "', '" + cliente.senha + "')";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    loginAutorizado = Convert.ToBoolean(cmd.ExecuteScalar());
                }
                con.Close();
            }

            return loginAutorizado;
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

        private int ObterId (string nome)
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = "SELECT clienteId FROM cliente WHERE nome=" + nome + "";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    int id = (int)cmd.ExecuteScalar();
                }
                con.Close();
            }
            return id;
        }
    }
}
