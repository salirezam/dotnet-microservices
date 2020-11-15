using Data.Repository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository<Order> repository;

        public GetOrderByIdQueryHandler(IOrderRepository<Order> repository)
        {
            this.repository = repository;
        }
        public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return repository.Get(request.Id);
        }
    }
}
