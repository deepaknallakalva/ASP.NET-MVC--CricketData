using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CricketData.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace CricketData.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryPlayer> CountryPlayer { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Comments> Comment { get; set; }

    }
}

