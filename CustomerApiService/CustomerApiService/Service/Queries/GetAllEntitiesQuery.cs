using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Queries
{
    public class GetAllEntitiesQuery<T>: IRequest<IEnumerable<T>>
        where T: class, IEntity
    {
    }
}
