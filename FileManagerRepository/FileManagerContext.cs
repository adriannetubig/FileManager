using FileManagerDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FileManagerRepository
{
    public sealed class FileManagerContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<FileLocation> FileLocations { get; set; }

        public FileManagerContext(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("ConnectionString Required");

            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                .UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileLocation>(a =>
            {
                a.ToTable("FileLocation").HasKey(b => b.Id);
                a.Property(b => b.Id).HasColumnName("FileLocationId");
            });
        }
    }
}
