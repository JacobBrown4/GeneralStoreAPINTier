using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeneralStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        }

        public DbSet<ProductEntity> Products {get; set;}
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}