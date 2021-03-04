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
    }
}
