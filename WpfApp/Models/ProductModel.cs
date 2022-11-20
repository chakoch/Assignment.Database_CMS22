using System;

namespace WpfApp.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public String? CustomerName { get; set; }
    }
}
