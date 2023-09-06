using mercado_dirma_backend.Commands;
using mercado_dirma_backend.Models.Transaction;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class TransactionBusiness
    {
        public async Task<IEnumerable<Transaction>> GetAll(bool isActive)
        {
            return await TransactionQuery.GetAll(isActive);
        }
        public async Task<Transaction> GetById(int idTransaction)
        {
            return await TransactionQuery.GetById(idTransaction);
        }
        public async Task<IEnumerable<Transaction>> GetByUser(int idUser)
        {
            return await TransactionQuery.GetByUser(idUser);
        }
        public async Task<bool> Insert(TransactionInsertDto transaction)
        {
            return await TransactionCommand.Insert(transaction);
        }
        public async Task<bool> Delete(int idTransaction)
        {
            return await TransactionCommand.Delete(idTransaction);
        }
        public async Task<bool> Update(TransactionUpdateDto transaction)
        {
            return await TransactionCommand.Update(transaction);
        }
    }
}
