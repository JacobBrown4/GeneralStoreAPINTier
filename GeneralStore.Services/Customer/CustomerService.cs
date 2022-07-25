using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Data;
using GeneralStore.Data.Entities;
using GeneralStore.Models.Customer;
using GeneralStore.Models.Transaction;
using Microsoft.EntityFrameworkCore;

namespace GeneralStore.Services.Customer
{
    public class CustomerService : ICustomerService
    {

        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> CreateCustomerAsync(CustomerCreate request)
        {
            var customerEntity = new CustomerEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            _dbContext.Customers.Add(customerEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<CustomerListItem>> GetAllCustomersAsync()
        {
            var list = _dbContext.Customers.Select(x => new CustomerListItem
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName,
            });

            return list;
        }
        public async Task<CustomerDetail> GetCustomerByIdAsync(int customerId)
        {
            var customerEntity = await _dbContext.Customers
            .FirstOrDefaultAsync(e =>
            e.Id == customerId);

            if (customerEntity != null)
            {
                return new CustomerDetail
                {
                    Id = customerEntity.Id,
                    FirstName = customerEntity.FirstName,
                    LastName = customerEntity.LastName,
                    Transactions = customerEntity.Transactions.Select(t => new TransactionListItemCustomer
                    {
                        Id = t.Id,
                        Product = t.Product.Name,
                        Quantity = t.Quantity,
                        TransactionCost = t.Quantity * t.Product.Price
                    }).ToList()
                };
            }

            return null;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerEdit request)
        {
            var customerOld = await _dbContext.Customers.FindAsync(request.Id);

            if (customerOld == null)
                return false;


            customerOld.FirstName = request.FirstName;
            customerOld.LastName = request.LastName;
            customerOld.Email = request.Email;


            _dbContext.Entry(customerOld).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customerEntity = await _dbContext.Customers.FindAsync(customerId);

            if (customerEntity == null)
                return false;

            _dbContext.Customers.Remove(customerEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}