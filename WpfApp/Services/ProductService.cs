using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Contexts;
using WpfApp.Models;
using WpfApp.Models.Entities;

namespace WpfApp.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task Create(ProductCreateModel model)
        {
            var productEntity = new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
            };
            _context.Add(productEntity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            var products = new List<ProductModel>();
            foreach (var product in await _context.Products.Include(x => x.CustomerName).ToListAsync())
                products.Add(new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CustomerId = product.CustomerId.Id,
                    CustomerName = product.CustomerName.Name
                });

            return products;
        }
    }
}
