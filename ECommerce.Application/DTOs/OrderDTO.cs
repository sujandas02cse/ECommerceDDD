﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public AddressDTO ShippingAddress { get; set; } = null!;

        public List<OrderItemDTO> Items { get; set; } = new();
    }
}
