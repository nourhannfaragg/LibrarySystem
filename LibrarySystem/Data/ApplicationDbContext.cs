using LibrarySystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;DataBase=LibrarySystemDB;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().HasKey(lo => new
            {
                lo.BookId,
                lo.BorroweId
            });
            modelBuilder.Entity<Book>().HasOne(o => o.Author)
                                       .WithMany(b => b.Books)
                                       .HasForeignKey(o => o.AuthorId);
            modelBuilder.Entity<Loan>().HasOne(b => b.Book)
                                       .WithMany(l => l.loans)
                                       .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<Loan>().HasOne(b => b.Borrower)
                                       .WithMany(l => l.Loans)
                                       .HasForeignKey(b => b.BorroweId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
