using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Service.Queries
{
    public class GetOrderByCustomerIdQuery: IRequest<IEnumerable<Order>>
    {
        public Guid CustomerId { get; set; }
    }
}
