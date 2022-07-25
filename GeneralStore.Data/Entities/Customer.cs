using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralStore.Data.Entities
{
    public class CustomerEntity
    {
        public CustomerEntity()
        {
            Transactions = new HashSet<TransactionEntity>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        // Lazy loaded FK relationships
        public virtual ICollection<TransactionEntity> Transactions { get; set; }
    }
}