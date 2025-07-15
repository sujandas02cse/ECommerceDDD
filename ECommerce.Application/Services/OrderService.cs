using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;

        private readonly IOrderRepository _orderRepository;

        private readonly OrderDomainService _orderDomainService;

        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;

        public OrderService(

          IProductRepository productRepository,
          IOrderRepository orderRepository,
           ICustomerRepository customerRepository,
          OrderDomainService orderDomainService,
          IMapper mapper)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _orderDomainService = orderDomainService;
            _mapper = mapper;

        }
        public Task<OrderDTO?> GetOrderByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> PlaceOrderAsync(CreateOrderRequestDTO request)
        {
           var customer=await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new ArgumentException("Customer not found");
            }

            var shippingAddress = new Address(
                request.ShippingAddress.Street,
                request.ShippingAddress.City,
                request.ShippingAddress.State,
                request.ShippingAddress.PostalCode,
                request.ShippingAddress.Country
                );

            var order = new Order(request.CustomerId,shippingAddress);

            foreach (var item in request.Items)
            { 
                var product=await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    throw new ArgumentException($"Product with ID {item.ProductId} not found");
                }
                order.AddItem(product, item.Quantity);
            }

            if(!_orderDomainService.CanPlaceOrder(customer,order.Items.ToList()))
                {
                throw new InvalidOperationException("Order cannot be placed due to business rules violation");
            }
            await _orderRepository.AddAsync(order);
            return order.Id;

        }
    }
}
