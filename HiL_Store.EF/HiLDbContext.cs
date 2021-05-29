using HiL_Store.Domain.Entities;
using HiL_Store.Domain.Entities.StoreEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.EF
{
    public class HiLDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }


        public HiLDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
