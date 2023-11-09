﻿using MySqlConnector;
using PetLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Controller
{
    class RastreadorController
    {
        private string conn;

        public RastreadorController()
        {
            Conexao conexao = new Conexao();
            conn = conexao.Conn;
        }

        public void NovoRastreador(Rastreador r)
        {
            string sql = $"INSERT INTO rastreador (clienteId, identificador, status) VALUES ({r.ClienteId},{r.Identificador}, 1)";

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

        public void ExcluirRastreador(int rastreadorId)
        {
            string sql = $"UPDATE rastreador SET status=0 WHERE rastreadorId={rastreadorId}";
            
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

        public List<Rastreador> ListaRastreadores(int clienteId)
        {
            string sql = $"SELECT * FROM rastreador WHERE clienteId={clienteId}";
            List<Rastreador> lista = new List<Rastreador>();

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Rastreador r = new Rastreador();

                        while (reader.Read())
                        {
                            r.RastreadorId = reader.GetInt32(0);
                            r.ClienteId = reader.GetInt32(1);
                            r.Identificador = reader.GetString(2);
                        }
                        lista.Add(r);
                    }
                }
                con.Close();
            }
            return lista;
        }

        public DadosRastreador Localizacao(int rastreadorId)
        {
            string sql = $"SELECT dataRecolhida, lagitude, longitude FROM rastreador WHERE rastreadorId={rastreadorId}";
            DadosRastreador dados = new DadosRastreador();

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dados.DataRecolhida = Convert.ToString(reader.GetDateTime(0));
                            dados.Latitude = reader.GetString(1);
                            dados.Longitude = reader.GetString(2);
                        }
                    }
                }
                con.Close();
            }
            return dados;
        }
    }
}