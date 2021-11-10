using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class ContextBase  : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnection());
                base.OnConfiguring(optionsBuilder);
            }

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

        //    base.OnModelCreating(builder);
        //}

        public DbSet<ProdutoModel> ProdutoModel { get; set; }

        public string GetStringConnection()
        {
            string strncon = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebAPI_3Camadas_2021;Integrated Security=False;User ID=sa;Password=61403641;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return strncon;
        }
    }
}
