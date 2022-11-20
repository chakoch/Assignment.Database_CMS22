using System;
using System.Collections.Generic;

namespace WpfApp.Models.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public ICollection<ProductEntity> OrderProducts  { get; set; }

    }
}
