var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



namespace FoodMenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<foodItem> menu = new List<foodItem>
            {
                new foodItem { Id = 1, Name = "Coca Cola 150 ml", Price = 2.50m },
                new foodItem { Id = 2, Name = "Insalata di pollo", Price = 5.20m },
                new foodItem { Id = 3, Name = "Pizza Margherita", Price = 10.00m },
                new foodItem { Id = 4, Name = "Pizza 4 Formaggi", Price = 12.50m },
                new foodItem { Id = 5, Name = "Pz patatine fritte", Price = 3.50m },
                new foodItem { Id = 6, Name = "Insalata di riso", Price = 8.00m },
                new foodItem { Id = 7, Name = "Frutta di stagione", Price = 5.00m },
                new foodItem { Id = 8, Name = "Pizza fritta", Price = 5.00m },
                new foodItem { Id = 9, Name = "Piadina vegetariana", Price = 6.00m },
                new foodItem { Id = 10, Name = "Panino Hamburger", Price = 7.90m }
            };

            List<foodItem> selectedItems = new List<foodItem>();
            bool isOrdering = true;

            while (isOrdering)
            {
                DisplayMenu(menu);

                Console.WriteLine("Seleziona un'opzione (1-11):");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= 1 && choice <= 10)
                    {
                        selectedItems.Add(menu[choice - 1]);
                        Console.WriteLine($"{menu[choice - 1].Name} aggiunto al conto.\n");
                    }
                    else if (choice == 11)
                    {
                        isOrdering = false;
                        PrintBill(selectedItems);
                    }
                    else
                    {
                        Console.WriteLine("Opzione non valida. Riprova.");
                    }
                }
                else
                {
                    Console.WriteLine("Inserisci un numero valido.");
                }
            }
        }

        static void DisplayMenu(List<foodItem> menu)
        {
            Console.WriteLine("==============MENU==============");
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Id}: {item.Name} (€ {item.Price})");
            }
            Console.WriteLine("11: Stampa conto finale e conferma");
            Console.WriteLine("==============MENU==============");
        }

        static void PrintBill(List<foodItem> selectedItems)
        {
            Console.WriteLine("\n==============CONTO==============");
            decimal total = 0;
            foreach (var item in selectedItems)
            {
                Console.WriteLine($"{item.Name}: € {item.Price}");
                total += item.Price;
            }
            decimal serviceCharge = 3.00m;
            total += serviceCharge;
            Console.WriteLine($"Servizio al tavolo: € {serviceCharge}");
            Console.WriteLine($"Totale: € {total}");
            Console.WriteLine("=================================");
            Console.WriteLine("Grazie per aver ordinato!");
        }
    }

    class foodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
