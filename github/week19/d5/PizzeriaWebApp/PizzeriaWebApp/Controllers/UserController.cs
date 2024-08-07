using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaWebApp.Data;
using System.Security.Claims;


namespace PizzeriaWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly PizzeriaDbContext _context;

        public UserController(PizzeriaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> HomeUtente()
        {
            var products = await _context.Products
                                         .Include(p => p.Ingredients)
                                         .ToListAsync();

            return View(products);
        }
       public async Task<IActionResult> Carrello()
       {
  

        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  
 
          if (!int.TryParse(userIdString, out int userId))
          {
       
          }
          var orderItems = await _context.OrderItems
           .Where(oi => oi.Order.UserId == userId)
           .Include(oi => oi.Product) 
           .ToListAsync();
 

           return View("~/Views/Account/Carrello.cshtml", orderItems);
        }


    }
}
