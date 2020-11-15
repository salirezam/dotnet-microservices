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
    public class GetPaidOrdersQueryHandler : IRequestHandler<GetPaidOrdersQuery, IEnumerable<Order>>
    {
        private readonly IRepository<Order> repository;

        public GetPaidOrdersQueryHandler(IOrderRepository<Order> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<Order>> Handle(GetPaidOrdersQuery request, CancellationToken cancellationToken)
        {
            return repository.
        }
    }
}
