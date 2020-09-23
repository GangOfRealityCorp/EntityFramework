using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RevertDatabase
{
    class ContextApp: DbContext
    {
        public DbSet<Phone> Phones { get; set; }

        public ContextApp()
        {
            Database.EnsureDeleted();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TestDB1; Trusted_Connection=true");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Ignore<Company>();
        //}
    }

    public class Phone
    { 
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public Company Company { get; set; }
    }

    
    public class Company
    {
        public int Id { get; set; }

        [NotMapped]
        public string Name { get; set; }

        public string address { get; set; }
    }
}
