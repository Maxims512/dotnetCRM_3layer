using NLayerApp.BLL.DTO;
using System.Collections.Generic;

namespace NLayerApp.BLL.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDto);
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetUsers();
        void UpdateUser(UserDTO userDto);
        void DeleteUser(int id);
        void Dispose();
    }
}