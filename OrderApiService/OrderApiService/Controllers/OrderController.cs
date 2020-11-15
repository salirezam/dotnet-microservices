using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApiService.Dtos;
using Service.Commands;
using Service.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public OrderController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Order(OrderDto order)
        {
            try
            {
                var command = new CreateOrderCommand
                {
                    Order = mapper.Map<Order>(order)
                };

                return await mediator.Send(command);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> PaidOrders()
        {
            try
            {
                return (await mediator.Send(new GetPaidOrdersQuery())).ToList();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("pay/{id}")]
        public async Task<ActionResult<Order>> Pay(Guid id)
        {
            try
            {
                var query = new GetOrderByIdQuery { Id = id };
                var order = await mediator.Send(query);
                if (order == null)
                {
                    return BadRequest($"No order found with the id {id}");
                }

                order.OrderState = OrderState.PAID;

                var command = new PayOrderCommand { Order = mapper.Map<Order>(order) };
                return await mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
