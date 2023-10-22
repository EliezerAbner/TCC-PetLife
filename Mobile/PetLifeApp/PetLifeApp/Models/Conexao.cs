using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PetLifeApp.Models
{
    class Conexao
    {
        public string Conn { get; set; }

        public Conexao() 
        {
            LoadJson();
        }

        private void LoadJson() 
        {
            string json = ReadJson();
            JObject jsonObject = JObject.Parse(json);

            var resultado = jsonObject["conn"]?.ToString();

            Conn = resultado;
        }

        private string ReadJson()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string jsonPath = "PetLifeApp.dbConn.dbConn.json";

            using (Stream stream = assembly.GetManifestResourceStream(jsonPath))
            {
                if (stream != null)
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string json = sr.ReadToEnd();
                        return json;
                    }
                }
                else
                {
                    throw new FileNotFoundException($"Recurso não encontrado: {jsonPath}");
                }
            }
        }
    }
}
