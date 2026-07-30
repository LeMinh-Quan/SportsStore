using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain;
using SportsStore.WebUI.Infrastructure; // Cần để dùng SessionExtensions
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers;

public class CartController : Controller
{
    private IProductRepository _repository;
    private SportsStore.WebUI.Models.Cart cartService;
    public CartController(IProductRepository repository, SportsStore.WebUI.Models.Cart cart)
    {
        _repository = repository;
        cartService = cart;
    }
    public ViewResult Index(string returnUrl)
    {
        return View(new CartIndexViewModel
        {
            Cart=cartService,
            ReturnUrl=returnUrl ?? "/"
        });
    }
    public RedirectToActionResult AddToCart(int productId, string returnUrl)
    {
        Product? product = (Product?)_repository.Products.FirstOrDefault(p=>p.ProductID==productId);
        if (product != null)
        {
            cartService.AddItem(product, 1);
        }
        return RedirectToAction("Index", new {returnUrl});
        
    }
    public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
    {
        Product? product = (Product?)_repository.Products.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            cartService.RemoveLine(product);
        }
        return RedirectToAction("Index", new { returnUrl });

    }

}