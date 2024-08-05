using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaWebApp.Data;
using PizzeriaWebApp.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class AccountController : Controller
{
    private readonly PizzeriaDbContext _context;
    private readonly ILogger<AccountController> _logger;

    public AccountController(PizzeriaDbContext context, ILogger<AccountController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View(new User());
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, "CookieAuth");

                var authProperties = new AuthenticationProperties
                {
                    // Configurazioni aggiuntive come il redirect dopo il login
                };

                await HttpContext.SignInAsync(
                    "CookieAuth",
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Reindirizzamento basato sul ruolo
                if (user.Role == "Administrator")
                {
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        return View(new User { Email = email });
    }

    [HttpPost]
    public async Task<IActionResult> Register(string name, string email, string password, string role, string adminPassword)
    {
        if (role == "User")
        {
            ModelState.Remove("adminPassword");
        }

        if (ModelState.IsValid)
        {
            if (role == "Administrator" && adminPassword != "100")
            {
                ModelState.AddModelError(string.Empty, "Invalid admin password.");
                ViewBag.InvalidAdminPassword = true; // Indica alla view che la password admin è errata
                return View("Login", new User { Name = name, Email = email, Password = password, Role = role });
            }

            var user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Role = role // Assicurati che il ruolo sia corretto ("User" o "Administrator")
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            _logger.LogInformation("User registered successfully: {User}", user);

            return RedirectToAction("Login");
        }

        // Log dettagliato degli errori
        foreach (var modelState in ModelState.Values)
        {
            foreach (var error in modelState.Errors)
            {
                _logger.LogWarning("ModelState error: {Error}", error.ErrorMessage);
            }
        }

        return View("Login", new User { Name = name, Email = email, Password = password, Role = role });
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("CookieAuth");
        return RedirectToAction("Index", "Home");
    }
}
