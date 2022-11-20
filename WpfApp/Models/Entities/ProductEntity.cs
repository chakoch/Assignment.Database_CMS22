using System;

namespace WpfApp.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public CustomerEntity CustomerId { get; set; }
        public CustomerEntity CustomerName { get; set; }

    }
}
