using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interfaces;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace NLayerApp.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }

        public void CreateOrder(OrderDTO orderDto)
        {
            var user = _database.Users.Get(orderDto.UserId);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            var order = new Order
            {
                Price = orderDto.Price,
                OrderDate = DateTime.UtcNow,
                UserId = user.Id,
                User = user
            };

            _database.Orders.Create(order);
            _database.Save();
        }

        public OrderDTO GetOrder(int id)
        {
            if (id == null)
                throw new ValidationException("Не указан ID заказа", "");

            var order = _database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Заказ не найден", "");

            return _mapper.Map<OrderDTO>(order);
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            var orders = _database.Orders.GetAll();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public void UpdateOrder(OrderDTO orderDto)
        {
            var existingOrder = _database.Orders.Get(orderDto.Id);
            if (existingOrder == null)
                throw new ValidationException("Заказ не найден", "");

            _mapper.Map(orderDto, existingOrder);
            _database.Orders.Update(existingOrder);
            _database.Save();
        }

        public void DeleteOrder(int id)
        {
            var order = _database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Заказ не найден", "");

            _database.Orders.Delete(id);
            _database.Save();
        }
        public void Dispose()
        {
            _database.Dispose();
        }
    }
}