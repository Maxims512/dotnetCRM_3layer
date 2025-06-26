using System;
using System.Collections.Generic;
using System.Linq;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using System.Data.Entity;

namespace NLayerApp.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private MobileContext db;

        public UserRepository(MobileContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Users.Update(user);
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User book = db.Users.Find(id);
            if (book != null)
                db.Users.Remove(book);
        }
    }
}