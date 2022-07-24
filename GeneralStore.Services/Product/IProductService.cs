using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Models.Products;

namespace GeneralStore.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListItem>> GetAllProductsAsync();
    }
}