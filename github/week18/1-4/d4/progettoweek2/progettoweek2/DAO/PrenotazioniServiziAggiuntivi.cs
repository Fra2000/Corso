namespace progettoweek2.DAO
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using progettoweek2.Models;

    public class PrenotazioniServiziAggiuntiviDao : DaoBase
    {
        public PrenotazioniServiziAggiuntiviDao(string connectionString) : base(connectionString) { }

        public List<PrenotazioniServiziAggiuntivi> GetAllPrenotazioniServiziAggiuntivi()
        {
            List<PrenotazioniServiziAggiuntivi> prenotazioniServizi = new List<PrenotazioniServiziAggiuntivi>();
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT ID, PrenotazioneID, ServizioAggiuntivoID FROM PrenotazioniServiziAggiuntivi", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prenotazioniServizi.Add(new PrenotazioniServiziAggiuntivi
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            PrenotazioneID = reader.GetInt32(reader.GetOrdinal("PrenotazioneID")),
                            ServizioAggiuntivoID = reader.GetInt32(reader.GetOrdinal("ServizioAggiuntivoID"))
                        });
                    }
                }


            }
            return prenotazioniServizi;
        }

        public bool AddPrenotazioneServizioAggiuntivo(PrenotazioniServiziAggiuntivi prenotazioneServizio)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO PrenotazioniServiziAggiuntivi (PrenotazioneID, ServizioAggiuntivoID) VALUES (@PrenotazioneID, @ServizioAggiuntivoID)", connection);
                command.Parameters.AddWithValue("@PrenotazioneID", prenotazioneServizio.PrenotazioneID);
                command.Parameters.AddWithValue("@ServizioAggiuntivoID", prenotazioneServizio.ServizioAggiuntivoID);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public PrenotazioniServiziAggiuntivi GetPrenotazioneServizioAggiuntivoById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM PrenotazioniServiziAggiuntivi WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new PrenotazioniServiziAggiuntivi
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            PrenotazioneID = reader.GetInt32(reader.GetOrdinal("PrenotazioneID")),
                            ServizioAggiuntivoID = reader.GetInt32(reader.GetOrdinal("ServizioAggiuntivoID"))
                        };
                    }
                }
            }
            return null;
        }

        public bool UpdatePrenotazioneServizioAggiuntivo(PrenotazioniServiziAggiuntivi prenotazioneServizio)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE PrenotazioniServiziAggiuntivi SET PrenotazioneID = @PrenotazioneID, ServizioAggiuntivoID = @ServizioAggiuntivoID WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", prenotazioneServizio.ID);
                command.Parameters.AddWithValue("@PrenotazioneID", prenotazioneServizio.PrenotazioneID);
                command.Parameters.AddWithValue("@ServizioAggiuntivoID", prenotazioneServizio.ServizioAggiuntivoID);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeletePrenotazioneServizioAggiuntivo(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM PrenotazioniServiziAggiuntivi WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

    }
}
