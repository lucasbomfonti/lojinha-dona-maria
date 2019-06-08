using System;
using Lojinha.DonaMaria.Domain;
using Microsoft.EntityFrameworkCore;

namespace Tmss_Back_end.Data.Repository.Context
{
    public class DataContext : DbContext, IDisposable
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderItens> OrderItens { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }

    }
}