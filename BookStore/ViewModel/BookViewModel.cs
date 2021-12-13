using BookStore.Helper;
using BookStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Upload)]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter book title")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Please enter a book author name")]
        public string? Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string? Description { get; set; }
        public string? Category { get; set; }
        [Required]
        [Display(Name = "Total Pages of Book")]
        [NumberValidator(50, ErrorMessage = "Book Pages should be atleast 50")]
        public int? TotalPages { get; set; }
        [Required]
        [Display(Name = "Language")]
        public int? Language_Id { get; set; }
        public string? Language { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;
        public IFormFile? CoverPhoto { get; set; }
        public string? ImageURL { get; set; }
        public ICollection<IFormFile>? BookGallery { get; set; }
        public List<GalleryViewModel>? Gallery { get; set; }

        public IFormFile? PDFBook { get; set; }
        public string? PDFBookURL { get; set; }

    }
}
