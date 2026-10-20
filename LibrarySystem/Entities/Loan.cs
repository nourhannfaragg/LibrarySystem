using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LibrarySystem.Entities
{
    public class Loan
    {
        public int BookId { get; set; }
        public int BorroweId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public Borrower Borrower { get; set; }
    }
}
