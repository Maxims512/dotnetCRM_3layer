using NLayerApp.DAL.Entities;
using System;

namespace NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}