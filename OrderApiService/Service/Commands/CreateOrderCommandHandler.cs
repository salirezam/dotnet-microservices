using Data.Repository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository<Order> repository;

        public CreateOrderCommandHandler(IOrderRepository<Order> repository)
        {
            this.repository = repository;
        }

        public Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return repository.Add(request.Order);
        }
    }
}
