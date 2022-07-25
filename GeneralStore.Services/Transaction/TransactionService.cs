using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralStore.Data;
using GeneralStore.Data.Entities;
using GeneralStore.Models.Transaction;
using Microsoft.EntityFrameworkCore;

namespace GeneralStore.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> CreateTransactionAsync(TransactionCreate request)
        {
            var transactionEntity = new TransactionEntity
            {
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                DateOfTransaction = DateTime.Now,
                Quantity = request.Quantity
            };
            _dbContext.Transactions.Add(transactionEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<TransactionListItem>> GetAllTransactionsAsync()
        {
            var list = _dbContext.Transactions.Select(x => new TransactionListItem
            {
                Id = x.Id,
                Customer = x.Customer.FirstName + " " + x.Customer.LastName,
                Product = x.Product.Name,
                Quantity = x.Quantity
            });

            return list;
        }
        public async Task<TransactionDetail> GetTransactionByIdAsync(int transactionId)
        {
            var transactionEntity = await _dbContext.Transactions
            .FirstOrDefaultAsync(e =>
            e.Id == transactionId);

            if (transactionEntity != null)
            {
                return new TransactionDetail
                {
                    Id = transactionEntity.Id,
                    Quantity = transactionEntity.Quantity,
                    DateOfTransaction = transactionEntity.DateOfTransaction,
                    CustomerName = transactionEntity.Customer.FirstName + " " + transactionEntity.Customer.LastName,
                    Product = transactionEntity.Product.Name,
                    CustomerId = transactionEntity.CustomerId,
                    ProductId = transactionEntity.ProductId
                };
            }

            return null;
        }

        public async Task<bool> UpdateTransactionAsync(TransactionEdit request)
        {
            var transactionOld = await _dbContext.Transactions.FindAsync(request.Id);

            if (transactionOld == null)
                return false;


            transactionOld.ProductId = request.ProductId;
            transactionOld.Quantity = request.Quantity;
            transactionOld.CustomerId = request.CustomerId;
            transactionOld.DateOfTransaction = request.DateOfTransaction;


            _dbContext.Entry(transactionOld).State = EntityState.Modified;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            var transactionEntity = await _dbContext.Transactions.FindAsync(transactionId);

            if (transactionEntity == null)
                return false;

            _dbContext.Transactions.Remove(transactionEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}