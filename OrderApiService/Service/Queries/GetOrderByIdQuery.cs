using Domain.Entities;
using MediatR;
using System;

namespace Service.Queries
{
    public class GetOrderByIdQuery: IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
