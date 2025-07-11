﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;

namespace NLayerApp.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private MobileContext db;

        public OrderRepository(MobileContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.User);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Orders.Update(order);
        }
        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Include(o => o.User).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}