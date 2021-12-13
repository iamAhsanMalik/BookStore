using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class LanguageViewModel
    {
        public int Language_Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
