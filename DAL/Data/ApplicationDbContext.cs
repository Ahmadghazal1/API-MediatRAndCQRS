using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(SeedCategory());
        }

        private IEnumerable<Category> SeedCategory()
        {
            var categories = new List<Category>()
            {
                new() { Id = 1, Name = "Action" },
                new() { Id= 2, Name = "Drama" },
                new() { Id = 3, Name = "Romantic" }
            };
            return categories;
        }
    }
}
