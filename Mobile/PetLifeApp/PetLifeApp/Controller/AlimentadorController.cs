using MySqlConnector;
using PetLifeApp.Models;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace PetLifeApp.Controller
{
    class AlimentadorController
    {
        private string conn;

        public AlimentadorController()
        {
            Conexao conexao = new Conexao();
            conn = conexao.Conn;
        }

        public bool NovoAlimentador(Alimentador al)
        {
            bool opOk = false;

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = $"CALL novo_alimentador({al.ClienteId}, '{al.NomeAlimentador}', '{al.Identificador}')";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = $"SELECT alimentadorId FROM alimentador WHERE nomeAlimentador='{al.NomeAlimentador}'";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    opOk = Convert.ToBoolean(cmd.ExecuteScalar());
                }
                con.Close();
            }
            return opOk;
        }

        public void EditarAlimentador(Alimentador al)
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = $"UPDATE alimentador SET nomeAlimentador='{al.NomeAlimentador}' WHERE alimentadorId={al.AlimentadorId}";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void ExcluirAlimentador(int alimentadorId)
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = $"UPDATE alimentador SET status=0 WHERE alimentadorId={alimentadorId}";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public List<Alimentador> ListaAlimentadores(int clienteId)
        {
            string sql = $"SELECT * FROM alimentador WHERE clienteId={clienteId}";
            List<Alimentador> lista = new List<Alimentador>();

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    { 
                        while (reader.Read())
                        {
                            Alimentador al = new Alimentador()
                            {
                                AlimentadorId = reader.GetInt32(0),
                                NomeAlimentador = reader.GetString(1),
                                ClienteId = reader.GetInt32(3),
                                Identificador = reader.GetString(4),
                            };
                            
                            if (al.AlimentadorId != 0)
                            {
                                lista.Add(al);
                            }
                        }
                    }
                }
                con.Close();
            }
            return lista;
        }

        public List<DadosAlimentador> ObterDados(int alimentadorId)
        {
            string sql = "SELECT DAY(horaRecolhida), SUM(qtdConsumidaAgua), SUM(qtdConsumidaRacao)" +
                         " FROM dadosRecebidos" +
                        $" WHERE alimentadorId={alimentadorId}" +
                         " GROUP BY DAY(horaRecolhida) DESC LIMIT 7";

            List<DadosAlimentador> listaDados = new List<DadosAlimentador>();

            using(MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DadosAlimentador dados = new DadosAlimentador()
                            {
                                Dia = Convert.ToString(reader[0]),
                                QtdeConsumidaAgua = Convert.ToDecimal(reader.GetFloat(1)),
                                QtdeConsumidaRacao = Convert.ToDecimal(reader.GetFloat(2))
                            };
                            listaDados.Add(dados);
                        }
                    }
                }
                con.Close();
            }            

            return listaDados;

            
        }

        public void DefinirHorarios(HorariosAlimentador h)
        {
            string sql = $"INSERT INTO horarios (alimentadorId, horario, qtdeDespejarRacao, qtdeDespejarAgua) VALUES({h.AlimentadorId},'{h.Horario}',{h.QtdeDespejarRacao}, {h.QtdeDespejarAgua})";

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

        public List<HorariosAlimentador> ListaHorarios(int alimentadorId)
        {
            List<HorariosAlimentador> lista = new List<HorariosAlimentador>();
            string sql = $"SELECT * FROM horarios WHERE alimentadorId={alimentadorId}";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HorariosAlimentador h = new HorariosAlimentador()
                            {
                                HorariosAlimentadorId = reader.GetInt32(0),
                                AlimentadorId = reader.GetInt32(1),
                                Horario = reader.GetTimeSpan(2),
                                QtdeDespejarRacao = reader.GetDecimal(3),
                                QtdeDespejarAgua = reader.GetDecimal(4)
                            };

                            lista.Add(h);
                        }
                    }
                }
                con.Close();
            }

            return lista;
        }
    }
}
