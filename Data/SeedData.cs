using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CRUDModel.Data;
using CRUD.Models;
using System;
using System.Linq;

namespace CRUDModel.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CRUDPDBContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CRUDPDBContext>>()))
        {
            // Look for any movies.
            if (context.ProductModel.Any())
            {
                return;   // DB has been seeded
            }
            context.ProductModel.AddRange(
                new ProductModel
                {
                    Code = 10,
                    Title = "Milk",
                    Price = 1.99M,
                },
                new ProductModel
                {
                    Code = 11,
                    Title = "Cheese",
                    Price = 2.99M,
                },
                new ProductModel
                {
                    Code = 12,
                    Title = "Bread",
                    Price = 0.99M,
                },
                new ProductModel
                {
                    Code = 13,
                    Title = "Meat",
                    Price = 3.99M,
                }
            );
            context.SaveChanges();
        }
    }
}