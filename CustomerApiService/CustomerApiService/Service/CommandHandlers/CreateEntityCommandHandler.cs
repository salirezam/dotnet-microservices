using Data.Repository;
using Domain.Entities;
using MediatR;
using Service.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.CommandHandlers
{
    public class CreateEntityCommandHandler<T> : IRequestHandler<CreateEntityCommand<T>, T>
        where T : class, IEntity
    {
        private readonly IRepository<T> repository;

        public CreateEntityCommandHandler(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public Task<T> Handle(CreateEntityCommand<T> request, CancellationToken cancellationToken)
        {
            return repository.Add(request.Entity);
        }
    }
}
