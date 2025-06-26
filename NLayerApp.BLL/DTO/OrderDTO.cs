using System;
using NLayerApp.DAL.Entities;

namespace NLayerApp.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime? Date { get; set; }
        public int UserId { get; set; }    
        public User User { get; set; }
    }
}