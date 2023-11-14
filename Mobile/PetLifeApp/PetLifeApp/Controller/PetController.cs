using MySqlConnector;
using PetLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Controller
{
    class PetController
    {
        private string conn;

        public PetController()
        {
            Conexao conexao = new Conexao();
            conn = conexao.Conn;
        }

        public void NovoPet(Pet pet)
        {
            string sql = "INSERT INTO pet (status, clienteId,nome,especie,dataNascimento,peso,porte,raca,observacao) " +
                         $"VALUES (1, {pet.ClienteId}, '{pet.Nome}', '{pet.Especie}', '{pet.DataNascimento}', '{pet.Peso}', '{pet.Porte}', '{pet.Raca}', '{pet.Observacao}')";

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

        public void EditarPet(Pet pet)
        {
            string sql = $"UPDATE pet " +
                         $"SET clienteId={pet.ClienteId}, nome='{pet.Nome}', especie='{pet.Especie}', dataNascimento='{pet.DataNascimento}', peso={pet.Peso}, porte='{pet.Porte}', raca='{pet.Raca}', observacao='{pet.Observacao}'" +
                         $"WHERE petId={pet.PetId}";

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

        public void ExcluirPet(int petId)
        {
            string sql = $"UPDATE pet SET status=0 WHERE petId={petId}";

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

        public List<Pet> CarregarPets(int clienteId)
        {
            List<Pet> lista = new List<Pet>();
            string sql = $"SELECT * FROM pet WHERE clienteId={clienteId} AND status=1";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pet listaPet = new Pet()
                            {
                                PetId = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                Especie = reader.GetString(3),
                                Nome = reader.GetString(4),
                                DataNascimento = Convert.ToString(reader.GetDateTime(5)),
                                Peso = Convert.ToDecimal(reader.GetFloat(6)),
                                Porte = reader.GetString(7),
                                Raca = reader.GetString(8),
                                Observacao = reader.GetString(9),
                            };

                            if(listaPet.PetId != 0)
                            {
                                lista.Add(listaPet);
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
