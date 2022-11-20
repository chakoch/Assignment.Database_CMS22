using System.Collections.Generic;

namespace WpfApp.Models
{
    public class OrderCreateModel
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
