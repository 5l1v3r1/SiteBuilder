﻿using Microsoft.EntityFrameworkCore;
using SiteBuilder.DataEntity.Models;
using System;

namespace SiteBuilder.DataEntity
{
    public class SiteBuilderDbContext : DbContext
    {
        public SiteBuilderDbContext()
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=sitebuilder.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>()
                .HasOne(a => a.Settings)
                .WithOne(b => b.Tenant)
                .HasForeignKey<SiteSettings>(b => b.TenantId);
        }
    }
}
