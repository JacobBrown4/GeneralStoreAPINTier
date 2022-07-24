using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Data;
using GeneralStore.Models.Products;

namespace GeneralStore.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<ProductListItem>> GetAllProductsAsync()
        {
            var list = _dbContext.Products.Select(x => new ProductListItem
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            });

            return list;
        }
    }
}