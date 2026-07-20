using Microsoft.AspNetCore.Mvc;
namespace SportsStore.WebUI.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new string[] { "Soccer", "Football", "Chess" };
            return View(categories);
        }


    }
}
