using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Data.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public virtual CustomerEntity Customer { get; set; } = null!;
        public virtual ProductEntity Product { get; set; } = null!;
    }
}