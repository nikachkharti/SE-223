﻿using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public string? ImageUrl { get; set; }
    }
}
