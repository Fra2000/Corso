namespace progettoweek2.DAO
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using progettoweek2.Models;

    public class ServizioAggiuntivoDao : DaoBase
    {
        public ServizioAggiuntivoDao(string connectionString) : base(connectionString) { }

        public List<ServizioAggiuntivo> GetAllServiziAggiuntivi()
        {
            List<ServizioAggiuntivo> servizi = new List<ServizioAggiuntivo>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT ID, DataServizio, Quantita, Prezzo, Tipologia FROM ServiziAggiuntivi", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        servizi.Add(new ServizioAggiuntivo
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            DataServizio = reader.GetDateTime(reader.GetOrdinal("DataServizio")),
                            Quantita = reader.GetInt32(reader.GetOrdinal("Quantita")),
                            Prezzo = reader.GetDecimal(reader.GetOrdinal("Prezzo")),
                            Tipologia = reader.GetString(reader.GetOrdinal("Tipologia"))
                        });
                    }
                }
            }
            return servizi;
        }

        public bool AddServizioAggiuntivo(ServizioAggiuntivo servizio)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO ServiziAggiuntivi (DataServizio, Quantita, Prezzo, Tipologia) VALUES (@DataServizio, @Quantita, @Prezzo, @Tipologia)", connection);
                command.Parameters.AddWithValue("@DataServizio", servizio.DataServizio);
                command.Parameters.AddWithValue("@Quantita", servizio.Quantita);
                command.Parameters.AddWithValue("@Prezzo", servizio.Prezzo);
                command.Parameters.AddWithValue("@Tipologia", servizio.Tipologia);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public ServizioAggiuntivo GetServizioAggiuntivoById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM ServiziAggiuntivi WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ServizioAggiuntivo
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            DataServizio = reader.GetDateTime(reader.GetOrdinal("DataServizio")),
                            Quantita = reader.GetInt32(reader.GetOrdinal("Quantita")),
                            Prezzo = reader.GetDecimal(reader.GetOrdinal("Prezzo")),
                            Tipologia = reader.GetString(reader.GetOrdinal("Tipologia"))
                        };
                    }
                }
            }
            return null;
        }

        public bool UpdateServizioAggiuntivo(ServizioAggiuntivo servizio)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE ServiziAggiuntivi SET DataServizio = @DataServizio, Quantita = @Quantita, Prezzo = @Prezzo, Tipologia = @Tipologia WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", servizio.ID);
                command.Parameters.AddWithValue("@DataServizio", servizio.DataServizio);
                command.Parameters.AddWithValue("@Quantita", servizio.Quantita);
                command.Parameters.AddWithValue("@Prezzo", servizio.Prezzo);
                command.Parameters.AddWithValue("@Tipologia", servizio.Tipologia);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteServizioAggiuntivo(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM ServiziAggiuntivi WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

    }
}
