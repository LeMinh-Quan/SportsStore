using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Models;

public class CartIndexViewModel
{
    public Cart Cart { get; set; } = new Cart();
    public string? ReturnUrl { get; set; }
}