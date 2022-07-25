using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Models.Transaction;

namespace GeneralStore.Models.Products
{
    public class ProductDetail
    {
        public ProductDetail()
        {
            Transactions = new List<TransactionListItemProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }
        public List<TransactionListItemProduct> Transactions { get; set; }
        public ProductType ProductType {get; set;}
        public double TransactionTotals {get; set;}
    }
}