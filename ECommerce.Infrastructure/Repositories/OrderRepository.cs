﻿using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ECommerceDbContext _dbContext;



        public OrderRepository(ECommerceDbContext dbContext)

        {

            _dbContext = dbContext;

        }



        public async Task AddAsync(Order order)

        {

            await _dbContext.Orders.AddAsync(order);

            await _dbContext.SaveChangesAsync();

        }



        public async Task<Order?> GetByIdAsync(int id)

        {

            return await _dbContext.Orders

                .Include(o => o.Items) //Eager Loading 

                .AsNoTracking()

                .FirstOrDefaultAsync(o => o.Id == id);

        }
    }
}
