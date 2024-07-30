using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W9.InTheOven.Models.Entities
{
    /// <summary>
    /// Una riga di un ordine.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Chiave.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Prodotto ordinato.
        /// </summary>
        public required Product Product { get; set; }
        /// <summary>
        /// Ordine al quale appartiene la riga.
        /// </summary>
        public required Order Order { get; set; }
        /// <summary>
        /// Quantità ordinata.
        /// </summary>
        public int Quantity { get; set; }
    }
}
