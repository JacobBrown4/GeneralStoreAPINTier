using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Models.Customer;

namespace GeneralStore.Services.Customer
{
    public interface ICustomerService
    {

        Task<bool> CreateCustomerAsync(CustomerCreate request);
        Task<IEnumerable<CustomerListItem>> GetAllCustomersAsync();

        Task<CustomerDetail> GetCustomerByIdAsync(int noteId);
        Task<bool> UpdateCustomerAsync(CustomerEdit request);

        Task<bool> DeleteCustomerAsync(int noteId);
    }
}
