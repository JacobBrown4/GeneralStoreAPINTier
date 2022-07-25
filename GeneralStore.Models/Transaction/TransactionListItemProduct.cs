using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Models.Customer;

namespace GeneralStore.Models.Transaction
{
    public class TransactionListItemProduct
    {
        public int Id { get; set; }
        public CustomerListItem Customer { get; set; }
        public int Quantity { get; set; }
        public double TransactionCost {get; set;}
    }
}