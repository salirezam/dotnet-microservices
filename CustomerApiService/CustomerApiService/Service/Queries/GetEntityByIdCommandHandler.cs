using Data.Repository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Queries
{
    public class GetEntityByIdCommandHandler<T> : IRequestHandler<GetEntityByIdCommand<T>, T>
        where T: class, IEntity
    {
        private readonly IRepository<T> repository;

        public GetEntityByIdCommandHandler(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public Task<T> Handle(GetEntityByIdCommand<T> request, CancellationToken cancellationToken)
        {
            return repository.Get(request.Id);
        }
    }
}
