using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CrudWindowsForms_AdoNet
{
    public class Usuario
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS; Initial Catalog=CrudWindowsForms; Integrated Security=True;";


        public bool OK()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        public List<Datos_Usuario> Get()
        {
            List<Datos_Usuario> usuarios = new List<Datos_Usuario>();

            string query = "SELECT Id, Nombre, Email FROM Usuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Datos_Usuario dato = new Datos_Usuario
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Email = reader.GetString(2)
                        };

                        usuarios.Add(dato);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return usuarios;
        }

        public Datos_Usuario Get(int Id)
        {
            string query = "SELECT Id, Nombre, Email FROM Usuario WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        Datos_Usuario dato = null;

                        if (reader.Read())
                        {
                            dato = new Datos_Usuario
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Email = reader.GetString(2)
                            };
                        }

                        reader.Close();
                        return dato;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Hay un error en la base de datos: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }


        public void Add(string Nombre, string Email)
        {
            string query = "INSERT INTO Usuario (Nombre, Email) VALUES (@Nombre, @Email)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Email", Email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Hay un error en la base de datos: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void Update(string Nombre, string Email, int Id)
        {
            string query = "UPDATE Usuario SET Nombre=@Nombre, Email=@Email WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Id", Id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Hay un error en la base de datos: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void Delete( int Id)
        {
            string query = "DELETE FROM Usuario WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Id", Id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Hay un error en la base de datos: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public class Datos_Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Email { get; set; }
        }
    }
}
