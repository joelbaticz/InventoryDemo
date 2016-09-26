using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Demo.Models;

namespace Demo.Services
{
    public class MyDbContext : DbContext
    {
        //tables
        public DbSet<Category> TblCategory { get; set; }
        public DbSet<Product> TblProduct { get; set; }

        //Override this virtual method from DbContext
        //To configure the connection string
        //Don't need to call the base class ( :base(option )
        //We are doing it differently from the docu
        //Last time we supplied the conn string from the controller through the constuctor here
        //We want to completly isolate this thing from the outside
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            //Define the conn string
            option.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=DemoDB; Trusted_Connection=True");


        }

    }
}
