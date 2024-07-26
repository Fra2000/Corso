using progettoweek2.DAO;
using progettoweek2.Models;
using System.Data.SqlClient;

public class PrenotazioneDao : DaoBase
{
    public PrenotazioneDao(string connectionString) : base(connectionString) { }

    public List<Prenotazione> GetAllPrenotazioni()
    {
        List<Prenotazione> prenotazioni = new List<Prenotazione>();
        using (var connection = GetConnection())
        {
            connection.Open();
            var command = new SqlCommand("SELECT ID, DataPrenotazione, NumeroProgressivoAnno, Anno, DataInizio, DataFine, Caparra, Tariffa, ServizioCamera FROM Prenotazioni", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    prenotazioni.Add(new Prenotazione
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        DataPrenotazione = reader.GetDateTime(reader.GetOrdinal("DataPrenotazione")),
                        NumeroProgressivoAnno = reader.GetInt32(reader.GetOrdinal("NumeroProgressivoAnno")),
                        Anno = reader.GetInt32(reader.GetOrdinal("Anno")),
                        DataInizio = reader.GetDateTime(reader.GetOrdinal("DataInizio")),
                        DataFine = reader.GetDateTime(reader.GetOrdinal("DataFine")),
                        Caparra = reader.GetDecimal(reader.GetOrdinal("Caparra")),
                        Tariffa = reader.GetDecimal(reader.GetOrdinal("Tariffa")),
                        ServizioCamera = reader.GetString(reader.GetOrdinal("ServizioCamera"))
                    });
                }
            }
        }
        return prenotazioni;
    }

    public bool AddPrenotazione(Prenotazione prenotazione)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            var command = new SqlCommand("INSERT INTO Prenotazioni (DataPrenotazione, NumeroProgressivoAnno, Anno, DataInizio, DataFine, Caparra, Tariffa, ServizioCamera) VALUES (@DataPrenotazione, @NumeroProgressivoAnno, @Anno, @DataInizio, @DataFine, @Caparra, @Tariffa, @ServizioCamera)", connection);
            command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
            command.Parameters.AddWithValue("@NumeroProgressivoAnno", prenotazione.NumeroProgressivoAnno);
            command.Parameters.AddWithValue("@Anno", prenotazione.Anno);
            command.Parameters.AddWithValue("@DataInizio", prenotazione.DataInizio);
            command.Parameters.AddWithValue("@DataFine", prenotazione.DataFine);
            command.Parameters.AddWithValue("@Caparra", prenotazione.Caparra);
            command.Parameters.AddWithValue("@Tariffa", prenotazione.Tariffa);
            command.Parameters.AddWithValue("@ServizioCamera", prenotazione.ServizioCamera);

            var result = command.ExecuteNonQuery();
            return result > 0;
        }
    }

    public Prenotazione GetPrenotazioneById(int id)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM Prenotazioni WHERE ID = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Prenotazione
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        DataPrenotazione = reader.GetDateTime(reader.GetOrdinal("DataPrenotazione")),
                        NumeroProgressivoAnno = reader.GetInt32(reader.GetOrdinal("NumeroProgressivoAnno")),
                        Anno = reader.GetInt32(reader.GetOrdinal("Anno")),
                        DataInizio = reader.GetDateTime(reader.GetOrdinal("DataInizio")),
                        DataFine = reader.GetDateTime(reader.GetOrdinal("DataFine")),
                        Caparra = reader.GetDecimal(reader.GetOrdinal("Caparra")),
                        Tariffa = reader.GetDecimal(reader.GetOrdinal("Tariffa")),
                        ServizioCamera = reader.GetString(reader.GetOrdinal("ServizioCamera"))
                    };
                }
            }
        }
        return null;
    }

    public bool UpdatePrenotazione(Prenotazione prenotazione)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            var command = new SqlCommand("UPDATE Prenotazioni SET DataPrenotazione = @DataPrenotazione, NumeroProgressivoAnno = @NumeroProgressivoAnno, Anno = @Anno, DataInizio = @DataInizio, DataFine = @DataFine, Caparra = @Caparra, Tariffa = @Tariffa, ServizioCamera = @ServizioCamera WHERE ID = @Id", connection);
            command.Parameters.AddWithValue("@Id", prenotazione.ID);
            command.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
            command.Parameters.AddWithValue("@NumeroProgressivoAnno", prenotazione.NumeroProgressivoAnno);
            command.Parameters.AddWithValue("@Anno", prenotazione.Anno);
            command.Parameters.AddWithValue("@DataInizio", prenotazione.DataInizio);
            command.Parameters.AddWithValue("@DataFine", prenotazione.DataFine);
            command.Parameters.AddWithValue("@Caparra", prenotazione.Caparra);
            command.Parameters.AddWithValue("@Tariffa", prenotazione.Tariffa);
            command.Parameters.AddWithValue("@ServizioCamera", prenotazione.ServizioCamera);

            var result = command.ExecuteNonQuery();
            return result > 0;
        }
    }

    public bool DeletePrenotazione(int id)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            var command = new SqlCommand("DELETE FROM Prenotazioni WHERE ID = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            var result = command.ExecuteNonQuery();
            return result > 0;
        }
    }

   
}
