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

    }
}
