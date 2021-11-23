using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieRental;

namespace MovieRental.Table
{

    public class MovieRentalDbContext : DbContext
    {
        private string _connectionString = " Server=DESKTOP-JV4E60U; Database=MovieRentalDB; Trusted_Connection=True";
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facilities>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Movies>()
               .Property(d => d.Title)
               .IsRequired();

            modelBuilder.Entity<Adress>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Adress>()
                .Property(b => b.Street)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Customers>()
                .Property(c => c.Name)
                .IsRequired();
            modelBuilder.Entity<Customers>()
               .Property(s => s.SecondName)
               .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
