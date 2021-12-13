using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int TotalPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? ImageURL { get; set; }
        public string? PDFBookURL { get; set; }

        [ForeignKey("Language")]
        public int Language_Id { get; set; }
        public Languages? Language { get; set; }
        public ICollection<BookGallery>? BookGallery { get; set; }
    }
}
