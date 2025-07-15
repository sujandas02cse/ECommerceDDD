using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Product mappings 
            CreateMap<Product, ProductDTO>();
            CreateMap<CreateProductDTO, Product>();
            // Order mappings 
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            // Address mapping 
            CreateMap<Address, AddressDTO>();
        }
    }
}
