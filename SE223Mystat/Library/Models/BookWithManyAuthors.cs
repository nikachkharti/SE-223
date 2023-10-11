﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Models
{
    public class BookWithManyAuthors
    {
        public Book? Book { get; set; }
        public List<Author>? Authors { get; set; }
        public List<Author>? AllAuthorsFromDatabase { get; set; }
        //ძველი კოდი არ წავშალე სპეციალურად თუ დაგჭირდებათ ჩმოსაშლელი მენიუს გამოყენება ეწყობა ესე.
        //public IEnumerable<SelectListItem>? AuthorsSelectList { get; set; }
        public List<string>? SelectedAuthors { get; set; }
    }
}
