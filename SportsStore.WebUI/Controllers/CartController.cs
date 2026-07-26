using Microsoft.AspNetCore.Mvc;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.Infrastructure;
using SportsStore.Domain;

namespace SportsStore.WebUI.Controllers;

public class CartController : Controller
{
    // Giả lập Database mẫu (Nếu dùng Repository thì inject IProductRepository vào đây)
    private readonly List<Product> mockDatabase = new List<Product>
{
    new Product
    {
        ProductID = 1,
        Name = "Giày chạy bộ",
        Price = 100,
        Description = "Giày chạy thể thao",
        Category = "Giày"
    },
    new Product
    {
        ProductID = 2,
        Name = "Vợt cầu lông",
        Price = 50,
        Description = "Vợt tập luyện",
        Category = "Cầu lông"
    }
};

    // Hàm dùng chung: Lấy giỏ hàng từ Session ra
    private Cart GetCart()
    {
        return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
    }

    // Hiển thị trang Giỏ hàng
    public IActionResult Index(string returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View(GetCart());
    }

    // Xử lý nút Thêm vào giỏ
    [HttpPost]
    public IActionResult AddToCart(int productId, string returnUrl)
    {
        Product? product = mockDatabase.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            Cart cart = GetCart();
            cart.AddItem(product, 1);
            HttpContext.Session.SetJson("Cart", cart); // Lưu cập nhật vào Session
        }

        if (!string.IsNullOrEmpty(returnUrl))
            return LocalRedirect(returnUrl);

        return RedirectToAction("Index");
    }

    // Xử lý nút Xóa khỏi giỏ
    [HttpPost]
    public IActionResult RemoveFromCart(int productId, string returnUrl)
    {
        Product? product = mockDatabase.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            Cart cart = GetCart();
            cart.RemoveLine(product);
            HttpContext.Session.SetJson("Cart", cart);
        }

        return RedirectToAction("Index", new { returnUrl });
    }
}