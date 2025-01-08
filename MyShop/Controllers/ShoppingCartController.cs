using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using Microsoft.AspNetCore.Http;

namespace MyShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShopContext _context;
        private List<ShoppingCartItem> _cartItems;


        public ShoppingCartController(ShopContext context)
        {
            _context = context;
            _cartItems = new List<ShoppingCartItem>();
        }

        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult AddToCart(int id)
        {
            var carToAdd = _context.Cars.Find(id);

            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var existingCartItem = cartItems.FirstOrDefault(item => item.Car.Id == id);

            if (existingCartItem != null) {
                existingCartItem.Quantity++;
            }
            else
            {
                cartItems.Add(new ShoppingCartItem 
                { Car = carToAdd,
                  Quantity = 1 
                });
            }

            HttpContext.Session.Set("Cart", cartItems);

            return RedirectToAction("ViewCart");
        }
    
        public IActionResult ViewCart()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var cartViewModel = new ShoppingCartViewModel
          {
              Items = cartItems,
              TotalPrice = cartItems.Sum(item => item.Car.Price * item.Quantity),
          };
            return View(cartViewModel);
        }

        public IActionResult RemoveItem(int id) 
        { 
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var itemToRemove = cartItems.FirstOrDefault(item => item.Car.Id == id);

            if (itemToRemove != null)

            {
               if(itemToRemove.Quantity > 1)
                {
                    itemToRemove.Quantity--;
                }
                else
                {
                    cartItems.Remove(itemToRemove);
                }
            }
            HttpContext.Session.Set("Cart", cartItems);

            return RedirectToAction("ViewCart");
        }
    }

}
