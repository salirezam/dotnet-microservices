using Data.Database;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OrderRepository : Repository<Order, OrderContext>, IOrderRepository<Order>
    {
        public OrderRepository(OrderContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid Id, CancellationToken cancellationToken)
        {
            return await dbSet.Where(x => x.CustomerId == Id).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetPaidOrderAsync(CancellationToken cancellationToken)
        {
            return await dbSet.Where(x => x.OrderState == OrderState.PAID).ToListAsync(cancellationToken);
        }
    }
}
