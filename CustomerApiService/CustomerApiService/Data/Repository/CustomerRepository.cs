using Data.Database;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class CustomerRepository: Repository<Customer, CustomerContext>
    {
        public CustomerRepository(CustomerContext context): base(context)
        {

        }
    }
}
