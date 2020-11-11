using AutoMapper;
using CustomerApiService.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApiService.Infrastructures.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerDto, Customer>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<UpdateCustomerDto, Customer>();
        }
    }
}
