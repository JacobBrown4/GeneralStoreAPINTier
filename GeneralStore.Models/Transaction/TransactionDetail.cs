using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Models.Transaction
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfTransaction { get; set; }

    }
}