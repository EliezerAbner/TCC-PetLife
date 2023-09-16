using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    class Cliente
    {
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
                string sql = "INSERT INTO cliente (nome, dataNascimento) VALUES ("+cliente.Nome+", "+cliente.dataNascimento+")";
                MySqlConnection con = new MySqlConnection(conn);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

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
