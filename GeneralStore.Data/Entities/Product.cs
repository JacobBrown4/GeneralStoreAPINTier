using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Data.Entities
{
    public class Product
    {
        public Product()
        {
            Transactions = new HashSet<Transaction>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}