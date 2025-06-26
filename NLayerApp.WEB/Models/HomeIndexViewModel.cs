using System.Collections.Generic;
using NLayerApp.BLL.DTO;

namespace NLayerApp.WEB.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<UserDTO> Users { get; set; }
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}