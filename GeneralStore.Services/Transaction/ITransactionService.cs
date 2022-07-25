using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Models.Transaction;

namespace GeneralStore.Services.Transaction
{
    public interface ITransactionService
    {
                Task<bool> CreateTransactionAsync(TransactionCreate request);
        Task<IEnumerable<TransactionListItem>> GetAllTransactionsAsync();
        
        Task<TransactionDetail> GetTransactionByIdAsync(int noteId);
        Task<bool> UpdateTransactionAsync(TransactionEdit request);       

        Task<bool> DeleteTransactionAsync(int noteId); 
    }
}