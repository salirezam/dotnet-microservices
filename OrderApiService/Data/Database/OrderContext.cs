using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Database
{
    public class OrderContext: DbContext
    {
        private DbSet<Order> OrderDb { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options): base(options)
        {
            var orders = new[] { 
                new Order
                {
                    Id = Guid.Parse("fdc23dfb-644f-4b83-a927-27a51192d5dc"),
                    CustomerId = Guid.Parse("f7f76ab4-9711-4d3a-9461-57638de7edc9"),
                    OrderState = OrderState.FINISHED,
                    CustomerFullName = "John Doe"
                },
                new Order
                {
                    Id = Guid.Parse("daa32240-b999-4d77-8d0b-881b0cff3f39"),
                    CustomerId = Guid.Parse("bbb0ffa3-c37a-45b4-8658-d080af2de683"),
                    OrderState = OrderState.UNPAID,
                    CustomerFullName = "Andrew McDonald"
                },
                new Order
                {
                    Id = Guid.Parse("2ec5c5bf-8f0d-40c2-91ca-107cc13d8a1b"),
                    CustomerId = Guid.Parse("a614a8a7-681e-4331-b0cf-b3bb98d854a4"),
                    OrderState = OrderState.PAID,
                    CustomerFullName = "Alireza Mo"
                }
            };

            OrderDb.AddRange(orders);
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "1.0");
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValue(new Guid());
                entity.Property(e => e.CustomerFullName).IsRequired();
            });
        }
    }
}
