using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerApiService.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Commands;
using Service.Queries;

namespace CustomerApiService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public CustomerController(IMapper mapper,IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Customer([FromBody] CreateCustomerDto customerDto)
        {
            try
            {
                var command = new CreateEntityCommand<Customer> { Entity = mapper.Map<Customer>(customerDto) };
                return await mediator.Send(command);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<ActionResult<Customer>> Customer([FromBody] UpdateCustomerDto customerDto)
        {
            try
            {
                var getCommand = new GetEntityByIdQuery<Customer> { Id = customerDto.Id };
                var customer =  await mediator.Send(getCommand);
                if (customer == null)
                    return BadRequest($"No customer found with id {customerDto.Id}");

                var updateCommand = new UpdateEntityCommand<Customer> { Entity = mapper.Map<Customer>(customerDto) };
                return await mediator.Send(updateCommand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
