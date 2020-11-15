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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository<Order> repository;

        public UpdateOrderCommandHandler(IOrderRepository<Order> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            await repository.UpdateRangeAsync(request.Orders);
            return Unit.Value;
        }
    }
}
