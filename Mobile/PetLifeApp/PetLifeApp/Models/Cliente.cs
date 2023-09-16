using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    class Cliente
    {
        private int id;

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

        private void Insercao(string sql)
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void NovoCliente(Cliente cliente)
        {
            try
            {
                Insercao("INSERT INTO cliente (nome, dataNascimento) VALUES (" + cliente.Nome + ", " + cliente.dataNascimento + ")");

                using (MySqlConnection con = new MySqlConnection())
                {
                    string sql = "SELECT clienteId FROM cliente WHERE nome=" + cliente.Nome + "";

                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        id = (int)cmd.ExecuteScalar();
                    }
                    con.Close();
                }

                Insercao("INSERT INTO endereco (clienteId, rua, numero, cep, cidade, estado) VALUES (" + id + ", " + cliente.Rua + ", " + cliente.Numero + ", " + cliente.Cep + ", " + cliente.Cidade + ", " + cliente.Estado + ", )");



                //inserir endereço
                //inserir email
                //inserir login
                //inserir telefone
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
