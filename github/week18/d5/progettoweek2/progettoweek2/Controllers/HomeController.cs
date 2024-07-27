using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Data.SqlClient;

public class HomeController : Controller
{
    private readonly string connectionString;

    public HomeController(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (VerifyUser(username, password))
        {
            return RedirectToAction("GestionePrenotazioni");
        }

        ViewBag.Error = "Invalid login credentials";
        return View("Index");
    }

    [HttpPost]
    public IActionResult Register(string username, string password, string ruolo, string nome, string cognome)
    {
        if (!UsernameExists(username))
        {
            bool saveSuccess = SaveUser(username, password, ruolo, nome, cognome);
            if (saveSuccess)
            {
                ViewBag.Message = "Registration successful. Please login.";
            }
            else
            {
                ViewBag.Error = "Registration failed due to an error saving the user.";
            }
        }
        else
        {
            ViewBag.Error = "Registration failed: Username already in use.";
        }
        return View("Index");
    }

    private bool SaveUser(string username, string password, string ruolo, string nome, string cognome)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("INSERT INTO Dipendenti (Username, PasswordHash, Ruolo, Nome, Cognome) VALUES (@Username, @PasswordHash, @Ruolo, @Nome, @Cognome)", connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@PasswordHash", password);  // Nota: Considerare l'hashing
            command.Parameters.AddWithValue("@Ruolo", ruolo);
            command.Parameters.AddWithValue("@Nome", nome);
            command.Parameters.AddWithValue("@Cognome", cognome);

            int result = command.ExecuteNonQuery();
            return result > 0;
        }
    }

    private bool VerifyUser(string username, string password)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT PasswordHash FROM Dipendenti WHERE Username = @Username", connection);
            command.Parameters.AddWithValue("@Username", username);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    var savedPasswordHash = reader.GetString(0);
                    return password == savedPasswordHash;
                }
            }
        }
        return false;
    }

    private bool UsernameExists(string username)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT COUNT(*) FROM Dipendenti WHERE Username = @Username", connection);
            command.Parameters.AddWithValue("@Username", username);

            int userCount = (int)command.ExecuteScalar();
            return userCount > 0;
        }
    }

    public IActionResult GestionePrenotazioni()
    {
        return View("GestionePrenotazioni");
    }

    public IActionResult Checkout()
    {
        return View();
    }
}