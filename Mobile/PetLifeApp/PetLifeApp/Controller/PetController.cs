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
            string sql = $"INSERT INTO pet (status, clienteId,nome,rg,dataNascimento,peso,porte,raca,observacao) " +
                         $"VALUES (1, {pet.ClienteId}, '{pet.Nome}', '{pet.Rg}', '{pet.DataNascimento}', '{pet.Peso}', '{pet.Porte}', '{pet.Raca}', '{pet.Observacao}')";

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
                         $"SET cliente={pet.ClienteId}, nome='{pet.Nome}', rg='{pet.Rg}', dataNascimento='{pet.DataNascimento}', peso={pet.Peso}, porte={pet.Porte}, raca='{pet.Raca}', observacao='{pet.Observacao}'";

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
                        Pet listaPet = new Pet();

                        while (reader.Read())
                        {
                            listaPet.PetId = (int)reader.GetInt32(0);
                            listaPet.ClienteId = (int)reader.GetInt32(1);
                            listaPet.Nome = Convert.ToString(reader.GetString(2));
                            listaPet.Rg = Convert.ToString(reader.GetString(3));
                            listaPet.DataNascimento = Convert.ToString(reader.GetDateTime(4));
                            listaPet.Peso = Convert.ToDecimal(reader.GetFloat(5));
                            listaPet.Porte = Convert.ToString(reader.GetString(6));
                            listaPet.Raca = Convert.ToString(reader.GetString(7));
                            listaPet.Observacao = Convert.ToString(reader.GetString(8));
                        }
                        lista.Add(listaPet);
                    }
                }
                con.Close();
            }

            return lista;
        }

    }
}
