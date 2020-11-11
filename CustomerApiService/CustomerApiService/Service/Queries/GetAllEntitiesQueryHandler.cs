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
    public class GetAllEntitiesQueryHandler<T> : IRequestHandler<GetAllEntitiesQuery<T>, IEnumerable<T>>
        where T: class, IEntity
    {
        private readonly IRepository<T> repository;

        public GetAllEntitiesQueryHandler(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public Task<IEnumerable<T>> Handle(GetAllEntitiesQuery<T> request, CancellationToken cancellationToken)
        {
            return repository.GetAll();
        }
    }
}
