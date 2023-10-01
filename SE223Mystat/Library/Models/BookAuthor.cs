using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class BookAuthor
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("BookId")]
        public Book? Book { get; set; }
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}
