using _1BW_BE.Models;

namespace _1BW_BE.Service
{
    public interface ICartService
    {
        Cart GetCartByUserId(int userId);
        void CreateCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(int cartId);

        void AddCartItem(CartItem cartItem);
        void UpdateCartItem(CartItem cartItem);
        void RemoveCartItem(int cartItemId);
        CartItem GetCartItemById(int cartItemId);
    }
}
