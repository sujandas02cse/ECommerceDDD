﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class OrderItem
    {
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        [MaxLength(200)]
        public string? ProductName { get; private set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public Order Order { get; private set; } = null!;
        private OrderItem() { } // EF Core 
        public OrderItem(int productId, string productName, decimal unitPrice, int quantity, Order order)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Order = order ?? throw new ArgumentNullException(nameof(order));
            OrderId = order.Id;
        }

        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
