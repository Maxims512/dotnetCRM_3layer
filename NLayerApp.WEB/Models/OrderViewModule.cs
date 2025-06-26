using NLayerApp.DAL.Entities;

namespace NLayerApp.WEB.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
    }
}