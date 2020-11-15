using Data.Repository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Commands
{
    public class CreateEntityCommandHandler<TEntity> : IRequestHandler<CreateEntityCommand<TEntity>, TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;

        public CreateEntityCommandHandler(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public Task<TEntity> Handle(CreateEntityCommand<TEntity> request, CancellationToken cancellationToken)
        {
            return repository.Add(request.Entity);
        }
    }
}
