namespace progettoweek2.DAO
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using progettoweek2.Models;

    public class DipendenteDao : DaoBase
    {
        public DipendenteDao(string connectionString) : base(connectionString) { }

        public List<Dipendente> GetAllDipendenti()
        {
            List<Dipendente> dipendenti = new List<Dipendente>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT ID, Username, PasswordHash, Nome, Cognome, Ruolo FROM Dipendenti", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dipendenti.Add(new Dipendente
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            Cognome = reader.GetString(reader.GetOrdinal("Cognome")),
                            Ruolo = reader.GetString(reader.GetOrdinal("Ruolo"))
                        });
                    }
                }
            }
            return dipendenti;
        }

        public bool AddDipendente(Dipendente dipendente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Dipendenti (Username, PasswordHash, Nome, Cognome, Ruolo) VALUES (@Username, @PasswordHash, @Nome, @Cognome, @Ruolo)", connection);
                command.Parameters.AddWithValue("@Username", dipendente.Username);
                command.Parameters.AddWithValue("@PasswordHash", dipendente.PasswordHash);
                command.Parameters.AddWithValue("@Nome", dipendente.Nome);
                command.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                command.Parameters.AddWithValue("@Ruolo", dipendente.Ruolo);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public Dipendente GetDipendenteById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Dipendenti WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Dipendente
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                            Nome = reader.GetString(reader.GetOrdinal("Nome")),
                            Cognome = reader.GetString(reader.GetOrdinal("Cognome")),
                            Ruolo = reader.GetString(reader.GetOrdinal("Ruolo"))
                        };
                    }
                }
            }
            return null;
        }

        public bool UpdateDipendente(Dipendente dipendente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Dipendenti SET Username = @Username, PasswordHash = @PasswordHash, Nome = @Nome, Cognome = @Cognome, Ruolo = @Ruolo WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", dipendente.ID);
                command.Parameters.AddWithValue("@Username", dipendente.Username);
                command.Parameters.AddWithValue("@PasswordHash", dipendente.PasswordHash);
                command.Parameters.AddWithValue("@Nome", dipendente.Nome);
                command.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                command.Parameters.AddWithValue("@Ruolo", dipendente.Ruolo);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteDipendente(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Dipendenti WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

    }
}
