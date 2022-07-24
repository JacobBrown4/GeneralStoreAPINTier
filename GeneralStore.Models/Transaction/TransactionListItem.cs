using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Models.Transaction
{
    public class TransactionListItem
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}