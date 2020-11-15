using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Service.Commands
{
    public class UpdateEntityCommand<T> : IRequest
        where T: class, IEntity
    {
        public List<T> Entities { get; set; }
    }
}
