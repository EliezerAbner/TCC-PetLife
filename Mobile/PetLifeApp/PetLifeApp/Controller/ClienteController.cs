using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using PetLifeApp.Models;

namespace PetLifeApp.Services
{
    class ClienteController
    {
        private static string conn;
        private int clienteId;

        public ClienteController() 
        {
            Conexao conexao = new Conexao();
            conn = conexao.Conn;
        }

        private int ObterId(string nome)
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = "SELECT clienteId FROM cliente WHERE nome=" + nome + "";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    clienteId = (int)cmd.ExecuteScalar();
                }
                con.Close();
            }
            return clienteId;
        }

        public void NovoCliente(Cliente cliente, Endereco endereco, LoginCliente login)
        {

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = "CALL novo_cliente('" + cliente.Nome + "', " + cliente.DataNascimento + ", '" + login.Email + "', '" + login.Senha + "', '" + endereco.Rua + "', '" + endereco.Numero + "', '" + endereco.Cep + "', '" + endereco.Cidade + "', '" + endereco.Estado + "', '" + cliente.Telefone + "')";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void EditarCliente(Cliente cliente, Endereco endereco, LoginCliente login)
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = "CALL editar_cliente(" + ObterId(cliente.Nome) + " '" + cliente.Nome + "', " + cliente.DataNascimento + ", '" + login.Email + "', '" + login.Senha + "', '" + endereco.Rua + "', '" + endereco.Numero + "', '" + endereco.Cep + "', '" + endereco.Cidade + "', '" + endereco.Estado + "', '" + cliente.Telefone + "')";
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
    }
}
