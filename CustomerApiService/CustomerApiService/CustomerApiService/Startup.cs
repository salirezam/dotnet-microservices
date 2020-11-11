using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomerApiService.Dtos;
using CustomerApiService.Validators;
using Data.Database;
using Data.Repository;
using Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.CommandHandlers;
using Service.Commands;
using Service.Queries;

namespace CustomerApiService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CustomerContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().AddFluentValidation();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IRepository<Customer>, CustomerRepository>();

            services.AddTransient<IValidator<CreateCustomerDto>, CreateCustomerDtoValidator>();
            services.AddTransient<IValidator<UpdateCustomerDto>, UpdateCustomerDtoValidator>();

            services.AddTransient<IRequestHandler<CreateEntityCommand<Customer>, Customer>, CreateEntityCommandHandler<Customer>>();
            services.AddTransient<IRequestHandler<UpdateEntityCommand<Customer>, Customer>, UpdateEntityCommandHandler<Customer>>();
            services.AddTransient<IRequestHandler<DeleteEntityCommand<Customer>, Customer>, DeleteEntityCommandHandler<Customer>>();
            services.AddTransient<IRequestHandler<GetEntityByIdQuery<Customer>, Customer>, GetEntityByIdQueryHandler<Customer>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
