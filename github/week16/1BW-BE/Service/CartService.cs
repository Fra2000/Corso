
using System.Data.SqlClient;

using _1BW_BE.Models;

namespace _1BW_BE.Service
{
    // Definizione della classe CartService che implementa l'interfaccia ICartService
    public class CartService : ICartService
    {
        private readonly string _connectionString;

        // Costruttore che inizializza la stringa di connessione dal file di configurazione
        public CartService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Ecom");
        }


        public CartItem GetCartItemById(int cartItemId)
        {
            CartItem cartItem = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT CartItemId, CartId, ProductId, Quantity
                               FROM dbo.CartItems
                               WHERE CartItemId = @CartItemId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CartItemId", cartItemId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cartItem = new CartItem
                            {
                                CartItemId = Convert.ToInt32(reader["CartItemId"]),
                                CartId = Convert.ToInt32(reader["CartId"]),
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            };
                        }
                    }
                }
            }

            return cartItem;
        }


        public Cart GetCartByUserId(int userId)
        {
            Cart cart = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Query SQL per recuperare il carrello dell'utente
                string sql = @"SELECT CartId, UserId, CreatedDate
                               FROM dbo.Carts
                               WHERE UserId = @UserId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Creazione di un oggetto Cart e assegnazione dei valori
                            cart = new Cart
                            {
                                CartId = Convert.ToInt32(reader["CartId"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                CartItems = GetCartItemsByCartId(Convert.ToInt32(reader["CartId"]))
                            };
                        }
                    }
                }
            }

            return cart;
        }

        /////////////////////////////////////////////////////////////////// CREATE //////////////////////////////////////////////////////////////////////////////////////////
        // Metodo per creare un nuovo carrello
        public void CreateCart(Cart cart)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Query SQL per inserire un nuovo carrello
                string sql = @"INSERT INTO dbo.Carts (UserId, CreatedDate)
                               VALUES (@UserId, @CreatedDate);
                               SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", cart.UserId);
                    command.Parameters.AddWithValue("@CreatedDate", cart.CreatedDate);
                    connection.Open();
                    // Recupera l'ID del carrello appena creato
                    int cartId = Convert.ToInt32(command.ExecuteScalar());
                    cart.CartId = cartId;
                }
            }
        }

        /////////////////////////////////////////////////////////////////// UPDATE //////////////////////////////////////////////////////////////////////////////////////////
        // Metodo per aggiornare un carrello esistente
        public void UpdateCart(Cart cart)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Query SQL per aggiornare i dati del carrello
                string sql = @"UPDATE dbo.Carts
                               SET UserId = @UserId,
                                   CreatedDate = @CreatedDate
                               WHERE CartId = @CartId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", cart.UserId);
                    command.Parameters.AddWithValue("@CreatedDate", cart.CreatedDate);
                    command.Parameters.AddWithValue("@CartId", cart.CartId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /////////////////////////////////////////////////////////////////// DELETE //////////////////////////////////////////////////////////////////////////////////////////
        // Metodo per eliminare un carrello dato il suo ID
        public void DeleteCart(int cartId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Query SQL per eliminare gli elementi del carrello
                        string deleteItemsSql = @"DELETE FROM dbo.CartItems
                                                  WHERE CartId = @CartId";

                        using (SqlCommand command = new SqlCommand(deleteItemsSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@CartId", cartId);
                            command.ExecuteNonQuery();
                        }

                        // Query SQL per eliminare il carrello
                        string deleteCartSql = @"DELETE FROM dbo.Carts
                                                 WHERE CartId = @CartId";

                        using (SqlCommand command = new SqlCommand(deleteCartSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@CartId", cartId);
                            command.ExecuteNonQuery();
                        }

                        // Commit della transazione
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback della transazione in caso di errore
                        transaction.Rollback();
                        throw new Exception("Errore durante l'eliminazione del carrello.", ex);
                    }
                }
            }
        }
        /////////////////////////////////////////////////////////////////// ADD TO CART //////////////////////////////////////////////////////////////////////////////////////////
        // Metodo per aggiungere un elemento al carrello
        public void AddCartItem(CartItem cartItem)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Query SQL per inserire un nuovo elemento nel carrello
                string sql = @"INSERT INTO dbo.CartItems (CartId, ProductId, Quantity)
                               VALUES (@CartId, @ProductId, @Quantity);
                               SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CartId", cartItem.CartId);
                    command.Parameters.AddWithValue("@ProductId", cartItem.ProductId);
                    command.Parameters.AddWithValue("@Quantity", cartItem.Quantity);
                    connection.Open();
                    // Recupera l'ID dell'elemento del carrello appena creato
                    int cartItemId = Convert.ToInt32(command.ExecuteScalar());
                    cartItem.CartItemId = cartItemId;
                }
            }
        }
        /////////////////////////////////////////////////////////////////// UPDATE CAT ITEM //////////////////////////////////////////////////////////////////////////////////////////
        // Metodo per aggiornare un elemento del carrello
        public void UpdateCartItem(CartItem cartItem)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Query SQL per aggiornare i dati di un elemento del carrello
                string sql = @"UPDATE dbo.CartItems
                               SET CartId = @CartId,
                                   ProductId = @ProductId,
                                   Quantity = @Quantity
                               WHERE CartItemId = @CartItemId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CartId", cartItem.CartId);
                    command.Parameters.AddWithValue("@ProductId", cartItem.ProductId);
                    command.Parameters.AddWithValue("@Quantity", cartItem.Quantity);
                    command.Parameters.AddWithValue("@CartItemId", cartItem.CartItemId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        /////////////////////////////////////////////////////////////////// REMUVE ITEM //////////////////////////////////////////////////////////////////////////////////////////
        // Metodo per rimuovere un elemento dal carrello
        public void RemoveCartItem(int cartItemId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Query SQL per recuperare la quantità e l'ID del prodotto dell'elemento del carrello
                        string getCartItemSql = @"SELECT Quantity, ProductId 
                                                  FROM dbo.CartItems 
                                                  WHERE CartItemId = @CartItemId";

                        int quantity = 0;
                        int productId = 0;

                        using (SqlCommand command = new SqlCommand(getCartItemSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@CartItemId", cartItemId);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    quantity = Convert.ToInt32(reader["Quantity"]);
                                    productId = Convert.ToInt32(reader["ProductId"]);
                                }
                            }
                        }

                        // Query SQL per aggiornare la quantità del prodotto nel marketplace
                        string updateProductSql = @"UPDATE dbo.Products
                                                    SET Quantity = Quantity + @Quantity
                                                    WHERE ProductId = @ProductId";

                        using (SqlCommand command = new SqlCommand(updateProductSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Quantity", quantity);
                            command.Parameters.AddWithValue("@ProductId", productId);
                            command.ExecuteNonQuery();
                        }

                        // Query SQL per rimuovere l'elemento dal carrello
                        string deleteCartItemSql = @"DELETE FROM dbo.CartItems
                                                     WHERE CartItemId = @CartItemId";

                        using (SqlCommand command = new SqlCommand(deleteCartItemSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@CartItemId", cartItemId);
                            command.ExecuteNonQuery();
                        }

                        // Commit della transazione
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback della transazione in caso di errore
                        transaction.Rollback();
                        throw new Exception("Errore durante la rimozione dell'elemento dal carrello e l'aggiornamento della quantità del prodotto.", ex);
                    }
                }
            }
        }
        /////////////////////////////////////////////////////////////////// GET CART ITEM ID//////////////////////////////////////////////////////////////////////////////////////////
        // Metodo privato per ottenere tutti gli elementi di un carrello dato l'ID del carrello
        private List<CartItem> GetCartItemsByCartId(int cartId)
        {
            List<CartItem> cartItems = new List<CartItem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Query SQL per recuperare tutti gli elementi di un carrello
                string sql = @"SELECT ci.CartItemId, ci.CartId, ci.ProductId, ci.Quantity,
                                      p.ProductId AS Product_ProductId, p.Name AS Product_Name,
                                      p.Description AS Product_Description, p.Price AS Product_Price
                               FROM dbo.CartItems ci
                               INNER JOIN dbo.Products p ON ci.ProductId = p.ProductId
                               WHERE ci.CartId = @CartId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CartId", cartId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Creazione di un oggetto CartItem e assegnazione dei valori
                            CartItem cartItem = new CartItem
                            {
                                CartItemId = Convert.ToInt32(reader["CartItemId"]),
                                CartId = Convert.ToInt32(reader["CartId"]),
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Product = new Product
                                {
                                    Name = reader["Product_Name"].ToString(),
                                    Description = reader["Product_Description"].ToString(),
                                    Price = Convert.ToDecimal(reader["Product_Price"])
                                }
                            };

                            cartItems.Add(cartItem);
                        }
                    }
                }
            }

            return cartItems;
        }
    }
}
