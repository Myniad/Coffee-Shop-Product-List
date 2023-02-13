using Coffee_Shop_Product_List.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Coffee_Shop_Product_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private CoffeeDbContext dbContext = new CoffeeDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> result = dbContext.Products.ToList();
            return View(result);
        }

        public IActionResult ProductDetails(int id)
        {
            Product result = dbContext.Products.FirstOrDefault(p => p.Id == id);
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}