using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;
using WebAPI.Contexts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task Create(CustomerCreateModel model)
        {
            var customerEntity = new CustomerEntity
            {
                Name = model.Name,
                Email = model.Email
            };
            _context.Add(customerEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            var customers = new List<CustomerModel>();
            foreach (var customer in await _context.Customers.ToListAsync())
                customers.Add(new CustomerModel { Id = customer.Id, Name = customer.Name, Email = customer.Email });

            return customers;
        }

        public async Task<CustomerModel> Get(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
                return new CustomerModel { Id = customerEntity.Id, Name = customerEntity.Name, Email = customerEntity.Email };

            return null!;
        }

        public async Task<CustomerModel> Update(CustomerModel cm)
        {
            var customerEntity = await _context.Customers.FindAsync(cm.Id);
            if (customerEntity == null)
            {
                return null!;
            }

            var costumerEntity = new
            {
                Id = cm.Id,
                Name = cm.Name,
                Email = cm.Email,
            };

            _context.Entry(costumerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return cm;


        }
    }
}
