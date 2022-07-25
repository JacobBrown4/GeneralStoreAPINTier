using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Models.Transaction;

namespace GeneralStore.Models.Customer
{
    public class CustomerDetail
    {
        public CustomerDetail()
        {
            Transactions = new List<TransactionListItem>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<TransactionListItem> Transactions { get; set; }
    }
}