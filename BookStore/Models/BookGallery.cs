using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class BookGallery
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        [ForeignKey("Books")]
        public int Book_Id { get; set; }
        public Books? Books { get; set; }
    }
}
