using ASP6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const double PEPPERONIPRICE = 94.99;
        private const double HAWAIIANPRICE = 89.99;
        private const double CHICKENBBQPRICE = 119.99;
        private const double MARGHERITAPRICE = 124.99;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user, bool pepperoni, bool hawaiian, bool chickenbbq, bool margherita)
        {
            int pepperoniCount = pepperoni ? 1 : 0;
            int hawaiianCount = hawaiian ? 1 : 0;
            int chickenbbqCount = chickenbbq ? 1 : 0;
            int margheritaCount = margherita ? 1 : 0;
            double price = PEPPERONIPRICE * pepperoniCount + HAWAIIANPRICE * hawaiianCount +
                CHICKENBBQPRICE * chickenbbqCount + MARGHERITAPRICE * margheritaCount;
            if (user.Age > 16)
                return Redirect($"/Order/Specify?pepperoni={pepperoniCount}&hawaiian={hawaiianCount}&" +
                    $"chickenbbq={chickenbbqCount}&margherita={margheritaCount}");
            else
                return Redirect($"/Order/Order/?pepperoni={pepperoniCount}&hawaiian={hawaiianCount}&" +
                    $"chickenbbq={chickenbbqCount}&margherita={margheritaCount}&price={price}");
        }
        public IActionResult Products()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Pepperoni", new List<string> { "pizza dough", "parmesan",
            "pepperoni", "mozarella", "tomato sauce", "oregana", "garlic" }, 30, PEPPERONIPRICE));
            products.Add(new Product("Margherita", new List<string> { "pizza dough", "tomatoes",
            "bazil", "mozarella", "olive oil", "oregana", "garlic" }, 30, HAWAIIANPRICE));
            products.Add(new Product("Hawaiian", new List<string> { "pizza dough", "cooked ham",
            "pineapples", "mozarella", "olive oil", "yeast" }, 45, CHICKENBBQPRICE));
            products.Add(new Product("Chicken BBQ", new List<string> { "pizza dough", "cooked chicken",
            "smoked gouda", "mozarella", "BBQ sauce", "oregana", "garlic" }, 45, MARGHERITAPRICE));
            return View(products);
        }
    }
}
