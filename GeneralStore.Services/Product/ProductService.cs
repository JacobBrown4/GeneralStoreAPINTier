using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Data;
using GeneralStore.Data.Entities;
using GeneralStore.Models.Customer;
using GeneralStore.Models.Products;
using GeneralStore.Models.Transaction;
using Microsoft.EntityFrameworkCore;

namespace GeneralStore.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> CreateProductAsync(ProductCreate request)
        {
            var productEntity = new ProductEntity
            {
                QuantityInStock = request.QuantityInStock,
                Name = request.Name,
                Price = request.Price,
                ProductType = (int)request.ProductType
            };
            _dbContext.Products.Add(productEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
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
        public async Task<ProductDetail> GetProductByIdAsync(int productId)
        {
            var productEntity = await _dbContext.Products
            .FirstOrDefaultAsync(e =>
            e.Id == productId);

            if (productEntity != null)
            {
                return new ProductDetail // LINQ Language integrated Query
                {
                    Id = productEntity.Id,
                    Price = productEntity.Price,
                    QuantityInStock = productEntity.QuantityInStock,
                    Name = productEntity.Name,
                    ProductType = (ProductType)productEntity.ProductType,
                    Transactions = productEntity.Transactions.Select(x => new TransactionListItemProduct
                    {
                        Id = x.Id,
                        Customer = new CustomerListItem{
                            Id = x.Customer.Id,
                            FullName = x.Customer.FirstName + " " + x.Customer.LastName
                        },
                        Quantity = x.Quantity,
                        TransactionCost = x.Quantity * productEntity.Price,

                    }).ToList(),
                    TransactionTotals = productEntity.Transactions.Select(x=>x.Quantity).ToList().Sum() * productEntity.Price
                };
            }

            return null;
        }

        public async Task<bool> UpdateProductAsync(ProductEdit request)
        {
            var productOld = await _dbContext.Products.FindAsync(request.Id);

            if (productOld == null)
                return false;


            productOld.Name = request.Name;
            productOld.QuantityInStock = request.QuantityInStock;
            productOld.Price = request.Price;


            _dbContext.Entry(productOld).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var productEntity = await _dbContext.Products.FindAsync(productId);

            if (productEntity == null)
                return false;

            _dbContext.Products.Remove(productEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}