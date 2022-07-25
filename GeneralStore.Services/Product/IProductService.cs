using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Models.Products;

namespace GeneralStore.Services
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(ProductCreate request);
        Task<IEnumerable<ProductListItem>> GetAllProductsAsync();
        
        Task<ProductDetail> GetProductByIdAsync(int noteId);
        Task<bool> UpdateProductAsync(ProductEdit request);       

        Task<bool> DeleteProductAsync(int noteId); 
    }
}