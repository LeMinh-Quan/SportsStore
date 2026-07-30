using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private Models.Cart cart;

        public CartSummaryViewComponent (Models.Cart cartService)
        {
            this.cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
