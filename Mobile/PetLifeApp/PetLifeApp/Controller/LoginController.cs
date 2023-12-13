using MySqlConnector;
using PetLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PetLifeApp.Controller
{
    class LoginController
    {
        private string conn;

        public LoginController()
        {
            Conexao conexao = new Conexao();
            conn = conexao.Conn;
        }

        public int VerificarEmail(LoginCliente login)
        {
            string sql = $"SELECT emailId FROM email WHERE email='{login.Email}' AND status=1";
            int emailId;

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    emailId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                con.Close();
            }

            return emailId;
        }

        public int VerificarSenha(LoginCliente login)
        {
            string sql = $"SELECT clienteId FROM login WHERE emailId={login.EmailId} AND senha='{login.Senha}'";
            int clienteId;

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    clienteId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                con.Close();
            }

            return clienteId;
        }
    }
}
