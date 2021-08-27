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
                using (MySqlCommand comm = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while(reader.Read())
                    {
                        var p = new Persona
                        {
                            Id = Convert.ToInt32(reader[nameof(Persona.Id)]),
                            Nombre = reader[nameof(Persona.Nombre)].ToString(),
                            Telefono = reader[nameof(Persona.Telefono)].ToString(), 
                        };
                        res.Add(p);
                    }
                    conn.Close();
                }
            }
            return res;
        }
    }
}