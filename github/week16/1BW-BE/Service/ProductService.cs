
using System.Data.SqlClient;

using _1BW_BE.Models;

namespace _1BW_BE.Service
{
    public class ProductService : IProductService
    {
        private readonly string _connectionString;

        public ProductService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Ecom");
        }

        //////////////////////////////////////////recupero tutti i prodotti
        public IEnumerable<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT p.ProductId, p.Name, p.Description, p.Price, p.Brand, p.Seller, p.Available, p.Quantity, i.ImageData
                       FROM dbo.Products p
                       LEFT JOIN dbo.ProductImages i ON p.ProductId = i.ProductId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Brand = reader["Brand"].ToString(),
                                Seller = reader["Seller"].ToString(),
                                Available = Convert.ToBoolean(reader["Available"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Images = new List<ProductImage>()
                            };

                            if (reader["ImageData"] != DBNull.Value)
                            {
                                product.Images.Add(new ProductImage
                                {
                                    ImageData = (byte[])reader["ImageData"]
                                });
                            }

                            // Imposta l'Availability a true se la Quantità è maggiore di zero
                            if (product.Quantity > 0)
                            {
                                product.Available = true;
                            }

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }


        //////////////////////////////////////////recupero prodotto per id
        public Product GetProductById(int productId)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT p.ProductId, p.Name, p.Description, p.Price, p.Brand, p.Seller, p.Available, p.Quantity, i.ImageData
                               FROM dbo.Products p
                               LEFT JOIN dbo.ProductImages i ON p.ProductId = i.ProductId
                               WHERE p.ProductId = @ProductId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Brand = reader["Brand"].ToString(),
                                Seller = reader["Seller"].ToString(),
                                Available = Convert.ToBoolean(reader["Available"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                Images = new List<ProductImage>()
                            };

                            if (reader["ImageData"] != DBNull.Value)
                            {
                                product.Images.Add(new ProductImage
                                {
                                    ImageData = (byte[])reader["ImageData"]
                                });
                            }
                        }
                    }
                }
            }

            return product;
        }

        //////////////////////////////////////////Creazione prodotto
        public void CreateProduct(Product product, IEnumerable<IFormFile> imageFiles)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sql = @"INSERT INTO dbo.Products (Name, Description, Price, Brand, Seller, Available, Quantity)
                                       VALUES (@Name, @Description, @Price, @Brand, @Seller, @Available, @Quantity);
                                       SELECT SCOPE_IDENTITY();";

                        using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Name", product.Name);
                            command.Parameters.AddWithValue("@Description", product.Description);
                            command.Parameters.AddWithValue("@Price", product.Price);
                            command.Parameters.AddWithValue("@Brand", product.Brand);
                            command.Parameters.AddWithValue("@Seller", product.Seller);
                            command.Parameters.AddWithValue("@Available", product.Available);
                            command.Parameters.AddWithValue("@Quantity", product.Quantity);

                            int productId = Convert.ToInt32(command.ExecuteScalar());
                            product.ProductId = productId;
                        }

                        foreach (var imageFile in imageFiles)
                        {
                            if (imageFile.Length > 0)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    imageFile.CopyTo(memoryStream);
                                    var imageData = memoryStream.ToArray();

                                    var insertImageCommand = new SqlCommand(
                                        "INSERT INTO dbo.ProductImages (ProductId, ImageData) VALUES (@ProductId, @ImageData)",
                                        connection, transaction);

                                    insertImageCommand.Parameters.AddWithValue("@ProductId", product.ProductId);
                                    insertImageCommand.Parameters.AddWithValue("@ImageData", imageData);

                                    insertImageCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        //////////////////////////////////////////aggiornamento prodotto
        public void UpdateProduct(Product product, IEnumerable<IFormFile> imageFiles = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sql = @"UPDATE dbo.Products
                               SET Name = @Name,
                                   Description = @Description,
                                   Price = @Price,
                                   Brand = @Brand,
                                   Seller = @Seller,
                                   Available = @Available,
                                   Quantity = @Quantity
                               WHERE ProductId = @ProductId";

                        using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ProductId", product.ProductId);
                            command.Parameters.AddWithValue("@Name", product.Name);
                            command.Parameters.AddWithValue("@Description", product.Description);
                            command.Parameters.AddWithValue("@Price", product.Price);
                            command.Parameters.AddWithValue("@Brand", product.Brand);
                            command.Parameters.AddWithValue("@Seller", product.Seller);
                            command.Parameters.AddWithValue("@Available", product.Available);
                            command.Parameters.AddWithValue("@Quantity", product.Quantity);
                            command.ExecuteNonQuery();
                        }

                        // Se sono fornite nuove immagini, gestisci l'aggiornamento delle immagini
                        if (imageFiles != null && imageFiles.Any())
                        {
                            // Elimina le immagini esistenti
                            string deleteImagesSql = "DELETE FROM dbo.ProductImages WHERE ProductId = @ProductId";
                            using (SqlCommand command = new SqlCommand(deleteImagesSql, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@ProductId", product.ProductId);
                                command.ExecuteNonQuery();
                            }

                            // Inserisci le nuove immagini
                            foreach (var imageFile in imageFiles)
                            {
                                if (imageFile.Length > 0)
                                {
                                    using (var memoryStream = new MemoryStream())
                                    {
                                        imageFile.CopyTo(memoryStream);
                                        var imageData = memoryStream.ToArray();

                                        var insertImageCommand = new SqlCommand(
                                            "INSERT INTO dbo.ProductImages (ProductId, ImageData) VALUES (@ProductId, @ImageData)",
                                            connection, transaction);

                                        insertImageCommand.Parameters.AddWithValue("@ProductId", product.ProductId);
                                        insertImageCommand.Parameters.AddWithValue("@ImageData", imageData);

                                        insertImageCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        //////////////////////////////////////////cancella prodotto
        public void DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Prima elimina tutte le immagini associate al prodotto
                        string deleteProductImagesSql = @"DELETE FROM dbo.ProductImages WHERE ProductId = @ProductId";
                        using (SqlCommand command = new SqlCommand(deleteProductImagesSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ProductId", productId);
                            command.ExecuteNonQuery();
                        }

                        // Poi elimina tutti i record correlati in CartItems
                        string deleteCartItemsSql = @"DELETE FROM dbo.CartItems WHERE ProductId = @ProductId";
                        using (SqlCommand command = new SqlCommand(deleteCartItemsSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ProductId", productId);
                            command.ExecuteNonQuery();
                        }

                        // Infine, elimina il prodotto stesso
                        string deleteProductSql = @"DELETE FROM dbo.Products WHERE ProductId = @ProductId";
                        using (SqlCommand command = new SqlCommand(deleteProductSql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ProductId", productId);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Errore durante l'eliminazione del prodotto e dei record correlati in CartItems o ProductImages.", ex);
                    }
                }
            }
        }

        //////////////////////////////////////////aggiunta immagine
        public void AddImageToProduct(int productId, IFormFile imageFile)
        {
            if (imageFile.Length > 0)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var memoryStream = new MemoryStream())
                    {
                        imageFile.CopyTo(memoryStream);
                        var imageData = memoryStream.ToArray();

                        var insertImageCommand = new SqlCommand(
                            "INSERT INTO dbo.ProductImages (ProductId, ImageData) VALUES (@ProductId, @ImageData)",
                            connection);

                        insertImageCommand.Parameters.AddWithValue("@ProductId", productId);
                        insertImageCommand.Parameters.AddWithValue("@ImageData", imageData);

                        insertImageCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        //////////////////////////////////////////recupero immagini per prodotto
        public IEnumerable<ProductImage> GetImagesByProductId(int productId)
        {
            var images = new List<ProductImage>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT ImageId, ImageData
                               FROM dbo.ProductImages
                               WHERE ProductId = @ProductId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var image = new ProductImage
                            {
                                ImageId = Convert.ToInt32(reader["ImageId"]),
                                ImageData = (byte[])reader["ImageData"]
                            };

                            images.Add(image);
                        }
                    }
                }
            }

            return images;
        }

        //////////////////////////////////////////cancellazione immagine
        public void DeleteImage(int imageId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = @"DELETE FROM dbo.ProductImages WHERE ImageId = @ImageId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ImageId", imageId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


         public IEnumerable<Product> SearchProducts(string query)
    {
        var products = new List<Product>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = @"SELECT p.ProductId, p.Name, p.Description, p.Price, p.Brand, p.Seller, p.Available, p.Quantity, i.ImageData
                           FROM dbo.Products p
                           LEFT JOIN dbo.ProductImages i ON p.ProductId = i.ProductId
                           WHERE p.Name LIKE @Query OR p.Description LIKE @Query OR p.Brand LIKE @Query OR p.Seller LIKE @Query";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Query", "%" + query + "%");
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Brand = reader["Brand"].ToString(),
                            Seller = reader["Seller"].ToString(),
                            Available = Convert.ToBoolean(reader["Available"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Images = new List<ProductImage>()
                        };

                        if (reader["ImageData"] != DBNull.Value)
                        {
                            product.Images.Add(new ProductImage
                            {
                                ImageData = (byte[])reader["ImageData"]
                            });
                        }

                        products.Add(product);
                    }
                }
            }
        }

        return products;
    }



    }
}
