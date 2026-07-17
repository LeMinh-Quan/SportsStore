using Microsoft.AspNetCore.Mvc;
using SportsStore.WebUI.Models;
using System.Diagnostics;
using SportsStore.Domain;

namespace SportsStore.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private IProductRepository _repository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IProductRepository repo,ILogger<HomeController> logger)
        {
            _logger = logger;
            _repository = repo;

        }

        public ViewResult Index() => View(_repository.Products);

        public IActionResult Privacy()
        {
            return View();
        }
            

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
