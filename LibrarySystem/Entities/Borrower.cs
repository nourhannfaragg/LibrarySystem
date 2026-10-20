using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibrarySystem.Entities
{
    public class Borrower
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime MemberShipDate { get; set; }

        public ICollection<Loan>Loans { get; set; }=new List<Loan>();
    }
}
