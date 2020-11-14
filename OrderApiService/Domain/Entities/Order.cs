using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Order: IEntity
    {
        public Guid Id { get; set; }
        public OrderState OrderState { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerFullName { get; set; }
    }
}
