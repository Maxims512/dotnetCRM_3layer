using System;
using System.ComponentModel.DataAnnotations;
namespace NLayerApp.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}