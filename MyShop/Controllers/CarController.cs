using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Controllers
{
    public class CarController : Controller
    {
        private readonly ShopContext _context;

        public CarController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("cars/{brand?}")]
        public IActionResult List(string brand = "all")
        {
            List<Car> cars;

            if (brand.Equals("all"))
            {
                cars = _context.Cars.ToList();
            }
            else
            {
                cars = _context.Cars.Where(c => c.Brand == brand).ToList();
            }

            return View(cars);
        }

        [Route("car/{id}/{slug?}")]
        public IActionResult Details(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null && car.ImageFileName != null)
            {
                car.ImageFileName = "/images/" + car.ImageFileName;
            }
            return View(car);
        }
    }
}
