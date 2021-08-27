using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace pruebaclase.Models
{
    public class RepoPersona
    {
        public string ConnectionString = "Server=localhost;Database=test;Uid=root;Pwd=;";

        public RepoPersona()
        {

        }

        public IList<Persona> ObtenerTodos()
        {
            IList<Persona> res = new List<Persona>();
            using(MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id, Nombre, Telefono FROM Persona";
                using (MySqlCommand conn = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = conn.ExecuteReader();
                    while(reader.Read())
                    {
                        
                    }
                }
            }
        }
    }
}