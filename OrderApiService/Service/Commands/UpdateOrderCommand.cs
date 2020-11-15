using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Service.Commands
{
    public class UpdateOrderCommand : IRequest
    {
        public List<Order> Orders { get; set; }
    }
}
