using System.Collections.Generic;
using System.Data.SqlClient;
using progettoweek2.Models;

namespace progettoweek2.DAO
{
    public class ClientiCamerePrenotazioniDao : DaoBase
    {
        public ClientiCamerePrenotazioniDao(string connectionString) : base(connectionString) { }

        public bool Add(ClientiCamerePrenotazioni ccp)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO ClientiCamerePrenotazioni (ClientiCamereID, PrenotazioniServiziID) VALUES (@ClientiCamereID, @PrenotazioniServiziID)", connection);
                command.Parameters.AddWithValue("@ClientiCamereID", ccp.ClientiCamereID);
                command.Parameters.AddWithValue("@PrenotazioniServiziID", ccp.PrenotazioniServiziID);
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM ClientiCamerePrenotazioni WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Puoi aggiungere altri metodi per la lettura o l'aggiornamento se necessario
    }
}
