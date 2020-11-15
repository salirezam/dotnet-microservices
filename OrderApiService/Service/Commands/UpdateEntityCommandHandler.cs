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
    public class UpdateEntityCommandHandler<TEntity> : IRequestHandler<UpdateEntityCommand<TEntity>>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;

        public UpdateEntityCommandHandler(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(UpdateEntityCommand<TEntity> request, CancellationToken cancellationToken)
        {
            await repository.UpdateRangeAsync(request.Entities);
            return Unit.Value;
        }
    }
}
