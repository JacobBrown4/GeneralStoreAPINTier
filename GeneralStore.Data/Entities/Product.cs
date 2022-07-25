using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Data.Entities
{
    public class ProductEntity
    {
        public ProductEntity()
        {
            Transactions = new HashSet<TransactionEntity>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int QuantityInStock { get; set; }
        [Required]
        public double Price { get; set; }

        public virtual ICollection<TransactionEntity> Transactions { get; set; }
    }
}