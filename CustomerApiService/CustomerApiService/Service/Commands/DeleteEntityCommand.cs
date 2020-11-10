using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Commands
{
    public class DeleteEntityCommand<T> : IRequest<T>
        where T : class, IEntity
    {
        public Guid Id { get; set; }
    }
}
