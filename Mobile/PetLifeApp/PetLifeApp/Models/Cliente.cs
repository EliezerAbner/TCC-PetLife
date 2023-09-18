using MySqlConnector;
using System;
using System.Collections.Generic;
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

        private static string conn = @"server=sql.freedb.tech;port=3306;database=freedb_matadoresDePorco;user id=freedb_user001;password=pk6rmPza!vD4MGY;charset=utf8";

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

        public void NovoCliente(Cliente cliente)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    string sql = "CALL novo_cliente('"+cliente.Nome+"', "+cliente.dataNascimento+", '"+cliente.Email+"', '"+cliente.senha+"', '"+cliente.Rua+"', '"+cliente.Numero+"', '"+cliente.Cep+"', '"+cliente.Cidade+"', '"+cliente.Estado+"', '"+cliente.Telefone+"')";
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditarCliente(Cliente cliente)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    ObterId(cliente.Nome);
                    string sql = "CALL editar_cliente("+id+" '"+cliente.Nome+"', "+cliente.dataNascimento+", '"+cliente.Email+"', '"+cliente.senha+"', '"+cliente.Rua+"', '"+cliente.Numero+"', '"+cliente.Cep+"', '"+cliente.Cidade+"', '"+cliente.Estado+"', '"+cliente.Telefone+"')";
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ExcluirCliente(int id)
        {
            try
            {
                using(MySqlConnection con = new MySqlConnection(conn))
                {
                    string sql = "CALL excluir_cliente("+id+")";
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
