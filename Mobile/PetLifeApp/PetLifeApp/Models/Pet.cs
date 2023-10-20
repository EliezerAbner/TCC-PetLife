using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetLifeApp.Models
{
    class Pet : Conexao
    {
        private string dataNascimento;
        public string DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = ConversorDatas(value); }
        }
        public int PetId { get; set; }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public decimal Peso { get; set; }
        public string Porte { get; set; }
        public string Raca { get; set; }
        public string Observacao { get; set; }

        private string ConversorDatas(string valorAntigo)
        {
            DateTime dataAntiga = Convert.ToDateTime(valorAntigo);
            string dataConvertida = dataAntiga.ToString("yyyy-MM-dd HH:mm:ss");

            return dataConvertida;
        }

        public void NovoPet()
        {
            string sql = $"INSERT INTO pet (status, clienteId,nome,rg,dataNascimento,peso,porte,raca,observacao) " +
                         $"VALUES (1, {this.ClienteId}, '{this.Nome}', '{this.Rg}', '{this.DataNascimento}', '{this.Peso}', '{this.Porte}', '{this.Raca}', '{this.Observacao}')";

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

        public void EditarPet()
        {
            string sql = $"UPDATE pet " +
                         $"SET cliente={this.ClienteId}, nome='{this.Nome}', rg='{this.Rg}', dataNascimento='{this.dataNascimento}', peso={this.Peso}, porte={this.Porte}, raca='{this.Raca}', observacao='{this.Observacao}'";

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

        public void ExcluirPet()
        {
            string sql = $"UPDATE pet SET status=0 WHERE petId={this.PetId}";

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
                            this.PetId = (int)reader.GetInt32(0);
                            this.ClienteId = (int)reader.GetInt32(1);
                            this.Nome = Convert.ToString(reader.GetString(2));
                            this.Rg = Convert.ToString(reader.GetString(3));
                            this.DataNascimento = Convert.ToString(reader.GetDateTime(4));
                            this.Peso = Convert.ToDecimal(reader.GetFloat(5));
                            this.Porte = Convert.ToString(reader.GetString(6));
                            this.Raca = Convert.ToString(reader.GetString(7));
                            this.Observacao = Convert.ToString(reader.GetString(8));
                        }
                        lista.Add(this);
                    }
                }
                con.Close();
            }

            return lista;
        } 
    }
}
