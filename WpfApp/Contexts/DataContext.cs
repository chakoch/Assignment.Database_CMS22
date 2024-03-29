﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models.Entities;

namespace WpfApp.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext > options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
