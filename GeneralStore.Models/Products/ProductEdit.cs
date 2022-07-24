using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Models.Products
{
    public class ProductEdit
    {
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }
        
    }
}