using Microsoft.EntityFrameworkCore;
using System;

namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                if (!db.Products.Any())
                {
                    for (int i = 1; i < 5001; i++)
                        db.Products.Add(new Product { Name = $"Product{i}" });
                    db.SaveChanges();
                }
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ApplicationContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductsDb;Trusted_Connection=True;");
        }
    }
}