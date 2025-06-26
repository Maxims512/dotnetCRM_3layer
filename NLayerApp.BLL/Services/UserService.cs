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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }      
        public void CreateUser(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _database.Users.Create(user);
            _database.Save();
        }

        public UserDTO GetUser(int id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id пользователя", "");

            var user = _database.Users.Get(id);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _database.Users.GetAll();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public void UpdateUser(UserDTO userDto)
        {
            var existingUser = _database.Users.Get(userDto.Id);
            if (existingUser == null)
                throw new ValidationException("Пользователь не найден", "");

            _mapper.Map(userDto, existingUser);
            _database.Users.Update(existingUser);
            _database.Save();
        }

        public void DeleteUser(int id)
        {
            var user = _database.Users.Get(id);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            _database.Users.Delete(id);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}