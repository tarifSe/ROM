using Microsoft.EntityFrameworkCore;
using ROM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.DBContext
{
    public class ROMDatabaseContext : DbContext
    {
        public ROMDatabaseContext(DbContextOptions<ROMDatabaseContext> options) : base(options)
        {

        }

        public DbSet<ROMTestModel> ROMTestModels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
