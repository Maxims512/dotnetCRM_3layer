using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MobileContext _db;
        private UserRepository _userRepository;
        private OrderRepository _orderRepository;
        private bool _disposed = false;

        public EFUnitOfWork(MobileContext context)
        {
            _db = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<User> Users =>
            _userRepository ??= new UserRepository(_db);

        public IRepository<Order> Orders =>
            _orderRepository ??= new OrderRepository(_db);

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _db.Entry(entity).State = EntityState.Added;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}