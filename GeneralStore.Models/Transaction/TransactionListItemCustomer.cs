using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Models.Transaction
{
    public class TransactionListItemCustomer
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double TransactionCost { get; set; }

    }
}