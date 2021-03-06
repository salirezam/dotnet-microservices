﻿using Data.Repository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Commands
{
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, Order>
    {
        private readonly IOrderRepository<Order> repository;

        public PayOrderCommandHandler(IOrderRepository<Order> repository)
        {
            this.repository = repository;
        }
        public Task<Order> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            return repository.Update(request.Order);
        }
    }
}
