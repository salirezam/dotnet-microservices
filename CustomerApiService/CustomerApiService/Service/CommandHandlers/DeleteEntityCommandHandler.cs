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
    public class DeleteEntityCommandHandler<T> : IRequestHandler<DeleteEntityCommand<T>, T>
        where T : class, IEntity
    {
        private readonly IRepository<T> repository;

        public DeleteEntityCommandHandler(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public Task<T> Handle(DeleteEntityCommand<T> request, CancellationToken cancellationToken)
        {
            return repository.Delete(request.Id);
        }
    }
}
