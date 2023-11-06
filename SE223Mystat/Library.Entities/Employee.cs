using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(11)]
        public string? Pin { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }


        [ForeignKey(nameof(Department))]
        [Required]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
