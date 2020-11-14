using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IRepository<T>
        where T : IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Delete(Guid id);
        Task<T> Update(T entity);
        Task<T> Add(T entity);
    }
}
