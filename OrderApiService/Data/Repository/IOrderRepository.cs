using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IOrderRepository<TEntity>: IRepository<TEntity>
        where TEntity: Order
    {
        Task<IEnumerable<TEntity>> GetPaidOrderAsync(CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetByCustomerIdAsync(Guid Id, CancellationToken cancellationToken);
    }
}
