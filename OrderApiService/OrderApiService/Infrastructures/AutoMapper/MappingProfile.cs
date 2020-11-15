using AutoMapper;
using Domain.Entities;
using OrderApiService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApiService.Infrastructures.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDto, Order>().ForMember(x => x.OrderState, opt => opt.MapFrom(src => 1));
        }
    }
}
