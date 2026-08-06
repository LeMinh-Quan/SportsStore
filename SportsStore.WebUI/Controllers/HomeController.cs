using Microsoft.AspNetCore.Mvc;
using SportsStore.WebUI.Models;
using System.Diagnostics;
using SportsStore.WebUI.Infrastructure;
using SportsStore.Domain;

namespace SportsStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public int Pagesize = 6;// quy dinh moi trang 6 san pham
        private IProductRepository _repository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IProductRepository repo,ILogger<HomeController> logger)
        {
            _logger = logger;
            _repository = repo;

        }

        public ViewResult Index(string? category, int productPage = 1)
        {
            return View(new ProductsListViewModel
            {
                Products = _repository.Products
            .Where(p => category == null || p.Category == category)
            .OrderBy(p => p.ProductID)
            .Skip((productPage - 1) * Pagesize)
            .Take(Pagesize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = Pagesize,
                    TotalItems = category == null
                ? _repository.Products.Count()
                : _repository.Products.Where(e => e.Category == category).Count()
                }
            });
        }

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
