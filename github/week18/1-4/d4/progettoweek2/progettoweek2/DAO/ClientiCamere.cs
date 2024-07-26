namespace progettoweek2.DAO
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using progettoweek2.Models;

    public class ClientiCamereDao : DaoBase
    {
        public ClientiCamereDao(string connectionString) : base(connectionString) { }

        public List<ClientiCamere> GetAllClientiCamere()
        {
            List<ClientiCamere> clientiCamereList = new List<ClientiCamere>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT ID, ClienteID, CameraID FROM ClientiCamere", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientiCamereList.Add(new ClientiCamere
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            ClienteID = reader.GetInt32(reader.GetOrdinal("ClienteID")),
                            CameraID = reader.GetInt32(reader.GetOrdinal("CameraID"))
                        });
                    }
                }
            }
            return clientiCamereList;
        }

        public bool AddClientiCamere(ClientiCamere clientiCamere)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO ClientiCamere (ClienteID, CameraID) VALUES (@ClienteID, @CameraID)", connection);
                command.Parameters.AddWithValue("@ClienteID", clientiCamere.ClienteID);
                command.Parameters.AddWithValue("@CameraID", clientiCamere.CameraID);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public ClientiCamere GetClientiCamereById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM ClientiCamere WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ClientiCamere
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            ClienteID = reader.GetInt32(reader.GetOrdinal("ClienteID")),
                            CameraID = reader.GetInt32(reader.GetOrdinal("CameraID"))
                        };
                    }
                }
            }
            return null;
        }

        public bool UpdateClientiCamere(ClientiCamere clientiCamere)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE ClientiCamere SET ClienteID = @ClienteID, CameraID = @CameraID WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", clientiCamere.ID);
                command.Parameters.AddWithValue("@ClienteID", clientiCamere.ClienteID);
                command.Parameters.AddWithValue("@CameraID", clientiCamere.CameraID);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteClientiCamere(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM ClientiCamere WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }



    }
}
