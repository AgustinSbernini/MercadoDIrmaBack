using Dapper;
using mercado_dirma_backend.DataAccess;
using mercado_dirma_backend.Models.Transaction;

namespace mercado_dirma_backend.Commands
{
    public class TransactionCommand : DaoBase
    {
        public static async Task<bool> Insert(TransactionInsertDto transaction)
        {
            var sql = @"
                INSERT INTO [Transaction]
                    (IdTransactionType, IdUserFrom, IdUserTo, Amount, [Date], Active)
                VALUES (@TransactionType, @IdUserFrom, @IdUserTo, @Amount, @Date, 1)";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { 
                    transaction.TransactionType,  
                    transaction.IdUserFrom, 
                    transaction.IdUserTo,
                    transaction.Amount,
                    transaction.Date
                }) == 1;
            }
        }
        public static async Task<bool> Delete(int idTransaction)
        {
            var sql = @"
                UPDATE [Transaction]
                SET Active = 0 
                WHERE IdTransaction = @IdTransaction";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { IdTransaction = idTransaction }) == 1;
            }
        }
        public static async Task<bool> Update(TransactionUpdateDto transaction)
        {
            var sql = @"
                UPDATE [Transaction] 
                SET IdTransactionType = @TransactionType, 
                    IdUserFrom = @IdUserFrom, 
                    IdUserTo = @IdUserTo, 
                    Amount = @Amount, 
                    [Date] = @Date,
                    Active = @Active
                WHERE IdTransaction = @IdTransaction";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new
                {
                    transaction.IdTransaction,
                    transaction.TransactionType,
                    transaction.IdUserFrom,
                    transaction.IdUserTo,
                    transaction.Amount,
                    transaction.Date,
                    transaction.Active
                }) == 1;
            }
        }
    }
}
