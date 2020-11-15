using Domain.Entities;
using MediatR;

namespace Service.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
