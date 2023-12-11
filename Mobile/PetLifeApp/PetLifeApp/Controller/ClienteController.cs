﻿using MySqlConnector;
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
                string sql = "CALL novo_cliente('" + cliente.Nome + "', '" + cliente.DataNascimento + "', '" + login.Email + "', '" + login.Senha + "', '" + endereco.Rua + "', '" + endereco.Numero + "', '" + endereco.Cep + "', '" + endereco.Cidade + "', '" + endereco.Estado + "', '" + cliente.Telefone + "')";
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

        public List<String> BuscaEstados()
        {
            List<String> list = new List<String>();
            string sql = "SELECT * FROM estado";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(0));
                        }
                    }
                }
                con.Close();
            }
            return list;
        }

        public string Validacao(string email, string telefone)
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = $"SELECT emailId FROM email WHERE email ='{email}' AND status=1";

                con.Open();
                int result = 0;

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                con.Close();

                if (result != 0)
                {
                    return "email";
                }
            }

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = $"SELECT telefoneId FROM telefone WHERE telefone = '{telefone}' AND status=1";

                con.Open();
                string result = "";

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    result = Convert.ToString(cmd.ExecuteScalar());
                }
                con.Close();

                if (result != "")
                {
                    return "telefone";
                }
            }

            return "ok";
        }

        public string CarregarNome (int clienteId)
        {
            string nome = "";
            string sql = $"SELECT nome FROM cliente WHERE clienteId={clienteId}";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand (sql, con))
                {
                    nome = Convert.ToString(cmd.ExecuteScalar());
                }
                con.Close();
            }
            return nome;
        }

        public (Cliente, LoginCliente, Endereco) CarregarCliente(int clienteId)
        {
            Cliente cliente = new Cliente();
            LoginCliente login = new LoginCliente();
            Endereco endereco = new Endereco();

            string sql = " SELECT c.clienteId, c.nome, c.dataNascimento, email.email, l.senha, e.rua, e.numero, e.cep, cidade.nomeCidade, estado.estado " +
                         " FROM cliente c " +
                         " INNER JOIN email " +
                            " ON email.clienteId = c.clienteId " +
                         " INNER JOIN login l " +
                            " ON l.clienteId = c.clienteId " +
                         " INNER JOIN endereco e " +
                            " ON e.clienteId = c.clienteId " +
                         " INNER JOIN cidade " +
                            " ON cidade.cidadeId = e.cidadeId " +
                         " INNER JOIN estado " +
                            " ON estado.estado = cidade.estadoId " +
                        $" WHERE c.clienteId = {clienteId}";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql,con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cliente.Id = reader.GetInt32(0);
                            cliente.Nome = reader.GetString(1);
                            cliente.Telefone = reader.GetString(2);
                            cliente.DataNascimento = reader.GetString(3);
                            login.Email = reader.GetString(4);
                            login.Senha = reader.GetString(5);
                            endereco.Rua = reader.GetString(6);
                            endereco.Numero = reader.GetString(7);
                            endereco.Cep = reader.GetString(8);
                            endereco.Cidade = reader.GetString(9);
                            endereco.Estado = reader.GetString(10);
                        }
                    }
                }
                con.Close();
            }
            return (cliente, login, endereco);
            //(int resultInt, string resultString) = CarregarCliente();
        }
    }
}
