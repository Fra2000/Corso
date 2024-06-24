using System;
using System.Collections.Generic;
using primogiorno2.Models;
using primogiorno2.Models;

namespace FoodMenuAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<foodItems> menu = new List<foodItems>
            {
                new foodItems { Id = 1, Name = "Coca Cola 150 ml", Price = 2.50m },
                new foodItems { Id = 2, Name = "Insalata di pollo", Price = 5.20m },
                new foodItems { Id = 3, Name = "Pizza Margherita", Price = 10.00m },
                new foodItems { Id = 4, Name = "Pizza 4 Formaggi", Price = 12.50m },
                new foodItems { Id = 5, Name = "Pz patatine fritte", Price = 3.50m },
                new foodItems { Id = 6, Name = "Insalata di riso", Price = 8.00m },
                new foodItems { Id = 7, Name = "Frutta di stagione", Price = 5.00m },
                new foodItems { Id = 8, Name = "Pizza fritta", Price = 5.00m },
                new foodItems { Id = 9, Name = "Piadina vegetariana", Price = 6.00m },
                new foodItems { Id = 10, Name = "Panino Hamburger", Price = 7.90m }
            };
            List<foodItems> selectedItems = new List<foodItems>();
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

        static void DisplayMenu(List<foodItems> menu)
        {
            Console.WriteLine("==============MENU==============");
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Id}: {item.Name} (€ {item.Price})");
            }
            Console.WriteLine("11: Stampa conto finale e conferma");
            Console.WriteLine("==============MENU==============");
        }

        static void PrintBill(List<foodItems> selectedItems)
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
}
