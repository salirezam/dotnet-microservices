using Domain.Entities;
using MediatR;

namespace Service.Commands
{
    public class PayOrderCommand: IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
