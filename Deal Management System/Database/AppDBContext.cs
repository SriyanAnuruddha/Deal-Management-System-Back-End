﻿using Deal_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Deal_Management_System.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options):DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Deal> Deals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Deal>()
                .HasIndex(d => d.Slug)
                .IsUnique();
        }
    }
}
