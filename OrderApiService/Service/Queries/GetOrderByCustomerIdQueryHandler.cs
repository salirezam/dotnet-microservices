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
    public class GetOrderByCustomerIdQueryHandler : IRequestHandler<GetOrderByCustomerIdQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository<Order> repository;

        public GetOrderByCustomerIdQueryHandler(IOrderRepository<Order> repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<Order>> Handle(GetOrderByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            return repository.GetByCustomerIdAsync(request.CustomerId, cancellationToken);
        }
    }
}
