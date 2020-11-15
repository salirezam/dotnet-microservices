using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Service.Queries
{
    public class GetPaidOrdersQuery: IRequest<IEnumerable<Order>>
    {
    }
}
