using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        [Route("[area]/cars/{brand?}")]
        public IActionResult List(string brand = "all")
        {
            List<Car> cars;

            if (brand.Equals("all"))
            {
                cars = _context.Cars.ToList();
            }
            else
            {
                cars = _context.Cars.Where(b => b.Brand == brand).ToList();
            }

            return View(cars);
        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            if (id.HasValue)
            {
                var car = _context.Cars.Find(id.Value);
                if (car != null)
                {
                    return View("AddEdit", car);
                }
            }
            return View("AddEdit", new Car());
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            //Add operation if id is 0

            if (ModelState.IsValid)
            {
                if (car.Id == 0)
                {
                    _context.Cars.Add(car);
                }
                else
                {
                    _context.Cars.Update(car);
                }

                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View("AddEdit", car);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                return View(car);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}