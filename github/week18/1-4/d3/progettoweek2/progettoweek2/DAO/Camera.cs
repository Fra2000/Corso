namespace progettoweek2.DAO
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using progettoweek2.Models;

    public class CameraDao : DaoBase
    {
        public CameraDao(string connectionString) : base(connectionString) { }

        public List<Camera> GetAllCamere()
        {
            List<Camera> camere = new List<Camera>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT ID, NumeroCamera, Descrizione, Tipologia FROM Camere", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        camere.Add(new Camera
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            NumeroCamera = reader.GetInt32(reader.GetOrdinal("NumeroCamera")),
                            Descrizione = reader.IsDBNull(reader.GetOrdinal("Descrizione")) ? null : reader.GetString(reader.GetOrdinal("Descrizione")),
                            Tipologia = reader.GetString(reader.GetOrdinal("Tipologia"))
                        });
                    }
                }
            }
            return camere;
        }

        public bool AddCamera(Camera camera)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Camere (NumeroCamera, Descrizione, Tipologia) VALUES (@NumeroCamera, @Descrizione, @Tipologia)", connection);
                command.Parameters.AddWithValue("@NumeroCamera", camera.NumeroCamera);
                command.Parameters.AddWithValue("@Descrizione", camera.Descrizione ?? (object)DBNull.Value);  // Gestione dei valori null
                command.Parameters.AddWithValue("@Tipologia", camera.Tipologia);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public Camera GetCameraById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Camere WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Camera
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            NumeroCamera = reader.GetInt32(reader.GetOrdinal("NumeroCamera")),
                            Descrizione = reader.IsDBNull(reader.GetOrdinal("Descrizione")) ? null : reader.GetString(reader.GetOrdinal("Descrizione")),
                            Tipologia = reader.GetString(reader.GetOrdinal("Tipologia"))
                        };
                    }
                }
            }
            return null;
        }

        public bool UpdateCamera(Camera camera)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Camere SET NumeroCamera = @NumeroCamera, Descrizione = @Descrizione, Tipologia = @Tipologia WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", camera.ID);
                command.Parameters.AddWithValue("@NumeroCamera", camera.NumeroCamera);
                command.Parameters.AddWithValue("@Descrizione", camera.Descrizione ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Tipologia", camera.Tipologia);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteCamera(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Camere WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

    }
}
