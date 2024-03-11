using ASP6.Models;
using Microsoft.AspNetCore.Mvc;
using ASP6.models;

namespace ASP6.Controllers
{
    public class OrderController : Controller
    {
        private const double PEPPERONIPRICE = 94.99;
        private const double HAWAIIANPRICE = 89.99;
        private const double CHICKENBBQPRICE = 119.99;
        private const double MARGHERITAPRICE = 124.99;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Specify()
        {
            List<int> counts = new List<int>();
            foreach (var count in HttpContext.Request.Query)
            {
                counts.Add(Convert.ToInt32(count.Value));
            }
            return View(new Order(counts));
        }
        [HttpPost]
        public IActionResult Specify(int pepperoniCount, int hawaiianCount, int chickenbbqCount, int margheritaCount)
        {
            double price = PEPPERONIPRICE * pepperoniCount + HAWAIIANPRICE * hawaiianCount +
                CHICKENBBQPRICE * chickenbbqCount + MARGHERITAPRICE * margheritaCount;
            return Redirect($"~/Order/Order/?pepperoni={pepperoniCount}&hawaiian={hawaiianCount}&" +
                $"chickenbbq={chickenbbqCount}&margherita={margheritaCount}&price={price}");
        }
        [HttpGet]
        public IActionResult Order()
        {
            List<int> counts = new List<int>();
            double price = 0;
            foreach (var count in HttpContext.Request.Query)
            {
                if (count.Key.Equals("price"))
                    price = Math.Round(Convert.ToDouble(count.Value), 2);
                else
                    counts.Add(Convert.ToInt32(count.Value));
            }
            return View(new Order(counts, price));
        }
        [HttpPost]
        public IActionResult Order(double price)
        {
            return Redirect($"~/Order/Confirm/?price={price}");
        }
        [HttpGet]
        public IActionResult Confirm()
        {
            var query = HttpContext.Request.Query;
            double price = 0;
            foreach (var elem in query)
                if (elem.Key.Equals("price"))
                    price = Math.Round(Convert.ToDouble(elem.Value), 2);
            return View(price);
        }
    }
}
