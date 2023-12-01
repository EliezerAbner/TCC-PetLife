using MySqlConnector;
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

        public bool NovoRastreador(Rastreador r)
        {
            bool deuBom;

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = $"call novo_rastreador({r.ClienteId}, {r.PetId}, '{r.Identificador}')";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = $"SELECT rastreadorId FROM rastreador WHERE identificador='{r.Identificador}'";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    deuBom = Convert.ToBoolean(cmd.ExecuteScalar());
                }
                con.Close();
            }

            return deuBom;
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
            string sql = " SELECT r.identificador, r.clienteId, p.nome, p.especie " +
                         " FROM rastreador r " +
                         " INNER JOIN pet p " +
                         " ON r.petId = p.petId " +
                        $" WHERE r.clienteId={clienteId}";
            List<Rastreador> lista = new List<Rastreador>();

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rastreador r = new Rastreador()
                            {
                                Identificador = reader.GetString(0),
                                ClienteId = reader.GetInt32(1),
                                NomePet = reader.GetString(2),
                                Especie = reader.GetString(3),
                            };
                            lista.Add(r);
                        }
                        
                    }
                }
                con.Close();
            }
            return lista;
        }

        public DadosRastreador Localizacao(string identificador)
        {
            string sql = $"SELECT rastreadorDadosId, dataRecolhida, latitude, longitude FROM rastreadorDados WHERE identificador='{identificador}' ORDER BY rastreadorDadosId DESC LIMIT 1";
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
                            dados.DadosRastreadorId = (int)reader.GetInt32(0);
                            dados.DataRecolhida = Convert.ToString(reader.GetMySqlDateTime(1));
                            dados.Latitude = reader.GetString(2);
                            dados.Longitude = reader.GetString(3);
                        }
                    }
                }
                con.Close();
            }
            return dados;
        }

        public List<DadosRastreador> Caminho(string identificador)
        {
            List<DadosRastreador> linha = new List<DadosRastreador> ();
            string sql = $"SELECT dataRecolhida, latitude, longitude FROM rastreadorDados WHERE identificador='{identificador}' ORDER BY dataRecolhida DESC LIMIT 20";

            using(MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using(MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DadosRastreador dr = new DadosRastreador()
                            {
                                DataRecolhida = Convert.ToString(reader.GetMySqlDateTime(0)),
                                Latitude = reader.GetString(1),
                                Longitude = reader.GetString(2)
                            };
                            linha.Add(dr);
                        }
                    }
                }    
                con.Close();
            }

            return linha;
        }
    }
}
