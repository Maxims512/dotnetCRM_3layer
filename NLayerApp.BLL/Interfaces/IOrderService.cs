using NLayerApp.BLL.DTO;
using System.Collections.Generic;
namespace NLayerApp.BLL.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderDTO orderDto);
        void UpdateOrder(OrderDTO orderDto);
        void DeleteOrder(int id);
        OrderDTO GetOrder(int id);
        IEnumerable<OrderDTO> GetAllOrders();
        void Dispose();
    }
}