using Domain.Entities;
using MediatR;

namespace Service.Commands
{
    public class CreateEntityCommand<T> : IRequest<T>
        where T : class, IEntity
    {
        public T Entity { get; set; }
    }
}
