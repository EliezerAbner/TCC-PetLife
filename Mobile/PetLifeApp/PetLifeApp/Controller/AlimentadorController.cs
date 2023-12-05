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
                                Identificador = reader.GetString(0),
                                NomeAlimentador = reader.GetString(1),
                                ClienteId = reader.GetInt32(3)
                            };
                            
                            if (al.Identificador != null)
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

        public List<DadosAlimentador> ObterDados(string identificador)
        {
            string sql = " SELECT DAY(horaRecolhida), SUM(qtdConsumidaAgua), SUM(qtdConsumidaRacao)" +
                         " FROM alimentadorDadosRecolhidos" +
                        $" WHERE identificador='{identificador}'" +
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

        public void ExcluirHorarios(int horariosId)
        {
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                string sql = $"UPDATE alimentadorHorarios SET status=0 WHERE identificador={horariosId}";

                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void DefinirHorarios(HorariosAlimentador h)
        {
            string sql = $"INSERT INTO alimentadorHorarios (identificador, status, horario, qtdeDespejarRacao, qtdeDespejarAgua) VALUES('{h.AlimentadorId}', 1,'{h.Horario}',{h.QtdeDespejarRacao}, {h.QtdeDespejarAgua})";

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

        public List<HorariosAlimentador> ListaHorarios(string identificador)
        {
            List<HorariosAlimentador> lista = new List<HorariosAlimentador>();
            string sql = $"SELECT * FROM alimentadorHorarios WHERE identificador='{identificador}' AND status=1";

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
                                AlimentadorId = reader.GetString(1),
                                Horario = reader.GetTimeSpan(3),
                                QtdeDespejarRacao = reader.GetDecimal(4),
                                QtdeDespejarAgua = reader.GetDecimal(5)
                            };

                            if (h.AlimentadorId != null)
                            {
                                lista.Add(h);
                            }
                        }
                    }
                }
                con.Close();
            }

            return lista;
        }
    }
}
