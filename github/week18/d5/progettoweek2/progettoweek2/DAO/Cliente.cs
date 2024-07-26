namespace progettoweek2.DAO
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using progettoweek2.Models;

    public class ClienteDao : DaoBase
    {
        public ClienteDao(string connectionString) : base(connectionString) { }

        public List<Cliente> GetAllClienti()
        {
            List<Cliente> clienti = new List<Cliente>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT ID, CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare FROM Clienti", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clienti.Add(new Cliente
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            CodiceFiscale = reader.GetString(reader.GetOrdinal("CodiceFiscale")),
                            Cognome = reader.GetString(reader.GetOrdinal("Cognome")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            Citta = reader.GetString(reader.GetOrdinal("Citta")),
                            Provincia = reader.GetString(reader.GetOrdinal("Provincia")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                            Cellulare = reader.GetString(reader.GetOrdinal("Cellulare"))
                        });
                    }
                }
            }
            return clienti;
        }

        public bool AddCliente(Cliente cliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES (@CodiceFiscale, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)", connection);
                command.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                command.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                command.Parameters.AddWithValue("@Nome", cliente.Nome);
                command.Parameters.AddWithValue("@Citta", cliente.Citta);
                command.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public Cliente GetClienteById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Clienti WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            CodiceFiscale = reader.GetString(reader.GetOrdinal("CodiceFiscale")),
                            Cognome = reader.GetString(reader.GetOrdinal("Cognome")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            Citta = reader.GetString(reader.GetOrdinal("Citta")),
                            Provincia = reader.GetString(reader.GetOrdinal("Provincia")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                            Cellulare = reader.GetString(reader.GetOrdinal("Cellulare"))
                        };
                    }
                }
            }
            return null;
        }

        public bool UpdateCliente(Cliente cliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Clienti SET CodiceFiscale = @CodiceFiscale, Cognome = @Cognome, Nome = @Nome, Citta = @Citta, Provincia = @Provincia, Email = @Email, Telefono = @Telefono, Cellulare = @Cellulare WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", cliente.ID);
                command.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                command.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                command.Parameters.AddWithValue("@Nome", cliente.Nome);
                command.Parameters.AddWithValue("@Citta", cliente.Citta);
                command.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                command.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteCliente(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Clienti WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }



    }
}
