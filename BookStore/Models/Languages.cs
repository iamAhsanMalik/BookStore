using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Languages
    {
        [Key]
        public int Language_Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Books>? Books { get; set; }
    }
}
