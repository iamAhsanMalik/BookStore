using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BookStore.Helper
{
    public class EmailGeneratorTagHelper : TagHelper
    {
        public string? MyEmail { get; set; }
        public string? EmailName { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", $"mailto:{MyEmail}");
            output.Content.SetContent(EmailName);

        }
    }
}
