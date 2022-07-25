using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Models.Products
{
     public enum ProductType {grocery, electronic};
    public class ProductCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int QuantityInStock { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public ProductType ProductType {get; set;}
    }
}