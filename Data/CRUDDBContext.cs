using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUDModel.Data
{
    public class CRUDPDBContext : DbContext
    {
        public CRUDPDBContext (DbContextOptions<CRUDPDBContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD.Models.ProductModel> ProductModel { get; set; } = default!;
        public DbSet<CRUD.Models.ClientModel> ClientModel { get; set; } = default!;
        public DbSet<CRUD.Models.OrderModel> OrderModel { get; set; } = default!;

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<CRUD.Models.ProductModel>().ToTable("Product");
        //     modelBuilder.Entity<CRUD.Models.ClientModel>().ToTable("Client");
        //     modelBuilder.Entity<CRUD.Models.OrderModel>().ToTable("Order");
        // }
          public void AddProductToArray(ProductModel product)
        {
            // Create a new array to store the products.
            var products = new List<ProductModel>();

            // Add the new product to the array.
            products.Add(product);

            // Save the array to the database.
            ProductModel.AddRange(products);
        }
    }
}
