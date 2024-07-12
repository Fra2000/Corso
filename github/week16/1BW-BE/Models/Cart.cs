namespace _1BW_BE.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CartItem> CartItems { get; set; }
        public decimal Total { get; set; }  // Campo per il totale del carrello

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
