using Domain.Entities;
using MediatR;
using System;

namespace Service.Queries
{
    public class GetEntityByIdCommand<T>: IRequest<T>
        where T: class, IEntity
    {
        public Guid Id { get; set; }
    }
}
