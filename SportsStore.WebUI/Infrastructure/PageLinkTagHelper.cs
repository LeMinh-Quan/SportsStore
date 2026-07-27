using Microsoft.AspNetCore.Razor.TagHelpers;
namespace SportsStore.WebUI.Infrastructure
{
    public class PageLinkTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
        }
    }
}
