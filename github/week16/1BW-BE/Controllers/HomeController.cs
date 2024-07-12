using _1BW_BE.Models;
using _1BW_BE.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public HomeController(ILogger<HomeController> logger, IProductService productService, ICartService cartService)
    {
        _logger = logger;
        _productService = productService;
        _cartService = cartService;
    }

    ////////////////////////////////////////////////////////////////// PAGINA INIZIALE //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Azione per la pagina principale
    public IActionResult Index(string query, decimal? maxPrice)
    {
        IEnumerable<Product> products;

        // Verifica se è stata fornita una query di ricerca
        if (!string.IsNullOrEmpty(query))
        {
            products = _productService.SearchProducts(query);
        }
        else
        {
            products = _productService.GetAllProducts();
        }

        // Filtro per prezzo massimo, se fornito
        if (maxPrice.HasValue)
        {
            products = products.Where(p => p.Price <= maxPrice.Value);
        }

        // Esempio di ID utente fisso (considera una gestione dinamica degli utenti)
        int userId = 1;
        var cart = _cartService.GetCartByUserId(userId);
        ViewBag.Cart = cart;

        ViewBag.IsIndexPage = true; // Imposta la proprietà ViewBag per la pagina principale

        return View(products);
    }

    ////////////////////////////////////////////////////////////////// CEATE //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Azione per la creazione di un nuovo prodotto (pagina di visualizzazione)
    public IActionResult Create()
    {
        return View();
    }


    // Azione per la creazione di un nuovo prodotto (invocata al post del form)
    [HttpPost]
    public IActionResult Create(ProductViewModel model, IEnumerable<IFormFile> imageFiles)
    {
        if (ModelState.IsValid)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Brand = model.Brand,
                Seller = model.Seller,
                Available = model.Available,
                Quantity = model.Quantity
            };

            _productService.CreateProduct(product, imageFiles);
            return RedirectToAction("Index");
        }

        return View(model);
    }








    ////////////////////////////////////////////////////////////////// DETTAGLIO //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Azione per la visualizzazione dei dettagli del prodotto
    public IActionResult ProductDetails(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }



    // Azione per la visualizzazione dei dettagli di un prodotto
    public IActionResult Details(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }


     ////////////////////////////////////////////////////////////////// PAGINA ADMIN //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Azione per la pagina amministrativa
    public IActionResult Admin()
    {
        var products = _productService.GetAllProducts();
        return View(products);
    }


    ////////////////////////////////////////////////////////////////// DELETE //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    

    // Azione per eliminare un'immagine di un prodotto
    [HttpPost]
    public IActionResult DeleteImage(int imageId)
    {
        try
        {
            _productService.DeleteImage(imageId);
            TempData["Message"] = "Image deleted successfully.";
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Error deleting image: {ex.Message}";
        }

        // Reindirizza nuovamente alla pagina principale dopo aver eliminato l'immagine
        return RedirectToAction("Index");
    }



    // Azione per la visualizzazione della pagina di eliminazione di un prodotto
    public IActionResult DeleteProduct(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // Azione per l'eliminazione di un prodotto (invocata al post del form)
    [HttpPost]
    public IActionResult DeleteProduct(int id, IFormCollection collection)
    {
        _productService.DeleteProduct(id);
        return RedirectToAction("Index");
    }



    ////////////////////////////////////////////////////////////////// EDIT UPDATE //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Azione per la modifica di un prodotto (pagina di visualizzazione)
    public IActionResult Edit(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        var model = new ProductViewModel
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Brand = product.Brand,
            Seller = product.Seller,
            Available = product.Available,
            Quantity = product.Quantity,
            Images = product.Images,
            // Le immagini verranno gestite come IFormFile nel form di modifica
        };

        return View(model);
    }

    // Azione per la modifica di un prodotto (invocata al post del form)
    [HttpPost]
    public IActionResult Edit(ProductViewModel model, IEnumerable<IFormFile> imageFiles)
    {
        if (ModelState.IsValid)
        {
            var product = new Product
            {
                ProductId = model.ProductId,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Brand = model.Brand,
                Seller = model.Seller,
                Available = model.Available,
                Quantity = model.Quantity
            };

            if (model.ImageFiles == null || !model.ImageFiles.Any())
            {
                product.Images = _productService.GetImagesByProductId(model.ProductId).ToList();
            }

            _productService.UpdateProduct(product, imageFiles);
            return RedirectToAction("Index");
        }

        return View(model);
    }


    ////////////////////////////////////////////////////////////////// CARRELLO //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////// //////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Aggiunta di un prodotto al carrello
    [HttpPost]
    public IActionResult AddToCart(int productId, int quantity)
    {
        _logger.LogInformation($"AddToCart called with productId: {productId}, quantity: {quantity}");

        var product = _productService.GetProductById(productId);
        if (product == null)
        {
            return NotFound();
        }

        if (product.Quantity < quantity)
        {
            ViewBag.ErrorMessage = $"Non ci sono abbastanza unità disponibili per '{product.Name}'.";
            return View("Error");
        }

        int userId = 1; // Esempio di ID utente fisso

        Cart cart = _cartService.GetCartByUserId(userId);

        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId,
                CreatedDate = DateTime.Now,
                CartItems = new List<CartItem>()
            };
            _cartService.CreateCart(cart);
        }

        CartItem existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

        if (existingCartItem != null)
        {
            existingCartItem.Quantity += quantity;
            _cartService.UpdateCartItem(existingCartItem);
        }
        else
        {
            CartItem cartItem = new CartItem
            {
                CartId = cart.CartId,
                ProductId = productId,
                Quantity = quantity,
                Product = product
            };
            _cartService.AddCartItem(cartItem);
        }

        product.Quantity -= quantity;
        product.Available = product.Quantity > 0;

        _productService.UpdateProduct(product);

        return RedirectToAction("Cart"); // Reindirizza alla pagina del carrello
    }


    ////////////////////////////////////////////////////////////////// VISUALIZZA CARRELLO //////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Visualizzazione del carrello
    public IActionResult Cart()
    {
        int userId = 1; // Sostituisci con la tua logica per ottenere l'ID utente

        Cart cart = _cartService.GetCartByUserId(userId);

        if (cart == null || cart.CartItems.Count == 0)
        {
            ViewBag.Message = "Il carrello è vuoto.";
            return View(cart);
        }

        decimal total = 0;

        foreach (var cartItem in cart.CartItems)
        {
            if (cartItem.Product == null)
            {
                cartItem.Product = _productService.GetProductById(cartItem.ProductId);
            }

            total += cartItem.Product.Price * cartItem.Quantity;
        }

        cart.Total = total; // Imposta il totale nell'oggetto carrello
        ViewBag.Cart = cart;
        ViewBag.IsCartPage = true;
        return View(cart);
    }
    ////////////////////////////////////////////////////////////////// REMOVEITEM CARRELLO //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Rimozione di un elemento dal carrello
    [HttpPost]
    public IActionResult RemoveCartItem(int cartItemId, int quantityToRemove)
    {
        try
        {
            var cartItem = _cartService.GetCartItemById(cartItemId);

            if (cartItem == null)
            {
                return NotFound();
            }

            if (quantityToRemove >= cartItem.Quantity)
            {
                _cartService.RemoveCartItem(cartItemId);
            }
            else
            {
                cartItem.Quantity -= quantityToRemove;
                _cartService.UpdateCartItem(cartItem);
            }

            return RedirectToAction("Cart"); // Redirect back to the cart page
        }
        catch (Exception ex)
        {
            // Handle exception as needed
            ViewBag.ErrorMessage = "Error removing item from cart.";
            return View("Error");
        }
    }



    ////////////////////////////////////////////////////////////////// SVUOTA CARRELLO //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Svuota completamente il carrello
    [HttpPost]
    public IActionResult ClearCart()
    {
        int userId = 1; // Esempio di ID utente fisso
        Cart cart = _cartService.GetCartByUserId(userId);

        if (cart != null)
        {
            foreach (var cartItem in cart.CartItems.ToList())
            {
                _cartService.RemoveCartItem(cartItem.CartItemId);
            }
        }

        return RedirectToAction("Cart");
    }

    [HttpPost]
    public IActionResult RemoveQuantityFromCart(int cartItemId, int quantityToRemove)
    {
        // Ottieni il carrello dell'utente (sostituisci con la tua logica per ottenere l'ID utente)
        int userId = 1;
        Cart cart = _cartService.GetCartByUserId(userId);

        // Trova l'elemento nel carrello
        CartItem cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);

        if (cartItem == null)
        {
            return NotFound(); // Gestisci il caso in cui l'elemento non esista nel carrello
        }

        // Verifica se la quantità da rimuovere è valida
        if (quantityToRemove <= 0 || quantityToRemove > cartItem.Quantity)
        {
            // Gestisci il caso in cui la quantità da rimuovere non sia valida
            ViewBag.ErrorMessage = "Invalid quantity to remove.";
            return View("Error");
        }

        // Aggiorna la quantità nel carrello
        cartItem.Quantity -= quantityToRemove;

        // Aggiorna il carrello nel servizio
        _cartService.UpdateCartItem(cartItem);

        // Aggiorna anche la quantità disponibile del prodotto nel database (opzionale)
        var product = _productService.GetProductById(cartItem.ProductId);
        product.Quantity += quantityToRemove;
        product.Available = product.Quantity > 0;
        _productService.UpdateProduct(product);

        return RedirectToAction("Cart"); // Reindirizza alla pagina del carrello
    }





    ////////////////////////////////////////////////////////////////// RICERCA //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Azione per la ricerca di prodotti
    [HttpGet]
    public IActionResult Search(string query)
    {
        var products = _productService.SearchProducts(query);
        return View(products);
    }

    // Azione per la visualizzazione della pagina di privacy
    public IActionResult Privacy()
    {
        return View();
    }

    // Azione per la gestione degli errori
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
