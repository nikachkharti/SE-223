using Library.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Quantity { get; set; }

        public static implicit operator Book(BookWithManyAuthors v)
        {
            throw new NotImplementedException();
        }
    }
}
