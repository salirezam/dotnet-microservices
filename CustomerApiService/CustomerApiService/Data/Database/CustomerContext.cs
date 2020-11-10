using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Database
{
    public class CustomerContext: DbContext
    {
        private DbSet<Customer> CustomerDb { get; set; }
        public CustomerContext(DbContextOptions<CustomerContext> options): base(options)
        {
            var customers = new[]
            {
                 new Customer
                {
                    Id = Guid.Parse("f7f76ab4-9711-4d3a-9461-57638de7edc9"),
                    FirstName = "John",
                    LastName = "Doe",
                    Birthday = new DateTime(1982, 06, 12),
                    Age = 38
                },
                new Customer
                {
                    Id = Guid.Parse("bbb0ffa3-c37a-45b4-8658-d080af2de683"),
                    FirstName = "Andrew",
                    LastName = "McDonald",
                    Birthday = new DateTime(1987, 09, 07),
                    Age = 33
                },
                new Customer
                {
                    Id = Guid.Parse("a614a8a7-681e-4331-b0cf-b3bb98d854a4"),
                    FirstName = "Alireza",
                    LastName = "Mo",
                    Birthday = new DateTime(1985, 06, 25),
                    Age = 35
                }
            };

            CustomerDb.AddRange(customers);
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "1.0");

            modelBuilder.Entity<Customer>(entity => {
                entity.Property(e => e.Id).HasDefaultValue("(newid())");
                entity.Property(e => e.Birthday).HasColumnType("date");
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
            });
        }
    }
}
