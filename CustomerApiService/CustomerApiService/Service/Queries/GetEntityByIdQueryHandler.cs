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
    public class GetEntityByIdQueryHandler<T> : IRequestHandler<GetEntityByIdQuery<T>, T>
        where T: class, IEntity
    {
        private readonly IRepository<T> repository;

        public GetEntityByIdQueryHandler(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public Task<T> Handle(GetEntityByIdQuery<T> request, CancellationToken cancellationToken)
        {
            return repository.Get(request.Id);
        }
    }
}
