﻿using Microsoft.EntityFrameworkCore;
using MiniOnlineShop.Application.Interfaces.Context;
using MiniOnlineShop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniOnlineShop.Persistance.Contexts
{
    public class QueryDbContext : DbContext, IQueryDbContext
    {
        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User>? Users { get; set; }
    }
}
