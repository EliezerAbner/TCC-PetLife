using MySqlConnector;
using PetLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            

            string sql = $"SELECT * FROM dadosRecebidos " +
                         $"WHERE alimentadorId={alimentadorId} AND horaRecolhida >= (DAY(CURDATE()) - 7) AND horaRecolhida <= CURDATE() " +
                         $"ORDER BY horaRecolhida DESC";
            
            List<DadosAlimentador> listaDados = new List<DadosAlimentador>();

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        DadosAlimentador dados = new DadosAlimentador();

                        while (reader.Read())
                        {
                            dados.DadosAlimentadorId = reader.GetInt32(0);
                            dados.DataRecolhida = Convert.ToString(reader.GetString(1));
                            dados.QtdeConsumidaAgua = Convert.ToDecimal(reader.GetFloat(2));
                            dados.QtdeConsumidaRacao = Convert.ToDecimal(reader.GetFloat(3));
                        }

                        listaDados.Add(dados);
                    }
                }
                con.Close();
            }

            return listaDados;
        }

        public void DefinirHorarios(List<HorariosAlimentador> horarios, int alimentadorId)
        {
            foreach (HorariosAlimentador h in horarios)
            {
                string sql = $"INSERT INTO horarios (alimentadorId, horario, quantidadeDespejar) VALUES({alimentadorId},'{h.Horario}',{h.QtdeDespejar})";

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
        }
    }
}
