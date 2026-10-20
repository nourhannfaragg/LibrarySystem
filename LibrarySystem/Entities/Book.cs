using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibrarySystem.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        [Required]
        public Author Author { get; set; }

        public ICollection<Loan> loans { get; set; } = new List<Loan>();
    }
}
