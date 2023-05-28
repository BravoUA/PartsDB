using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartsDB.Models;

namespace PartsDB
{
     class dbConnect: DbContext
    {
        public DbContext dbContext { get; set; }
        public DbSet<Categor> Categor { get; set; }
        public DbSet<Parts> Parts { get; set; }

        public dbConnect()
        {

        }
        public dbConnect(DbContextOptions<dbConnect> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("DataSource=PARTDB.db;");
        }
    }
}
