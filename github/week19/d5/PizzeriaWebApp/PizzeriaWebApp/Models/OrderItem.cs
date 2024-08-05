using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaWebApp.Models
{
    /// <summary>
    /// Una riga di un ordine.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Prodotto ordinato.
        /// </summary>
        public int ProductId { get; set; }
        public Product Product { get; set; }

        /// <summary>
        /// Ordine al quale appartiene la riga.
        /// </summary>
        public int OrderId { get; set; }
        public Order Order { get; set; }

        /// <summary>
        /// Quantità ordinata.
        /// </summary>
        public int Quantity { get; set; }
    }
}
