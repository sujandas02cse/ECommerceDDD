using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int id);

        Task AddAsync(Order order);
    }
}
