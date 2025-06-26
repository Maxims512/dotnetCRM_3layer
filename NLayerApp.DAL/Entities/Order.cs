using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int Price { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
