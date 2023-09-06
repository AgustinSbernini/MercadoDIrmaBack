using Dapper;
using mercado_dirma_backend.DataAccess;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.Transaction;
using System.Text;

namespace mercado_dirma_backend.Queries
{
    public class TransactionQuery : DaoBase
    {
        public static async Task<IEnumerable<Transaction>> GetAll(bool isActive)
        {
            var sql = new StringBuilder(@"
                SELECT T.IdTransaction
	                , T.IdTransactionType AS TransactionType
	                , T.Amount
	                , T.[Date]
	                , T.Active
	                , UF.IdUser
	                , UF.Email  
	                , UF.FullName  
	                , UT.IdUser
	                , UT.Email  
	                , UT.FullName  
                FROM [Transaction] T
                INNER JOIN [User] UF ON T.IdUserFrom = UF.IdUser
                INNER JOIN [User] UT ON T.IdUserTo = UT.IdUser
                ");

            if (isActive)
            {
                sql.Append(" WHERE T.Active = 1 ");
            }

            using (var db = GetConection())
            {
                return await db.QueryAsync<Transaction, User, User, Transaction>(sql.ToString(), (trans, userFrom, userTo) =>
                {
                    trans.UserFrom = userFrom;
                    trans.UserTo = userTo;
                    return trans;
                }, splitOn: "IdUser,IdUser");
            }
        }
        public static async Task<Transaction> GetById(int idTransaction)
        {
            var sql = @"
                SELECT T.IdTransaction
	                , T.IdTransactionType AS TransactionType
	                , T.Amount
	                , T.[Date]
	                , T.Active
	                , UF.IdUser
	                , UF.Email  
	                , UF.FullName  
	                , UT.IdUser
	                , UT.Email  
	                , UT.FullName  
                FROM [Transaction] T
                INNER JOIN [User] UF ON T.IdUserFrom = UF.IdUser
                INNER JOIN [User] UT ON T.IdUserTo = UT.IdUser
                WHERE T.IdTransaction = @IdTransaction";

            using (var db = GetConection())
            {
                var tran = await db.QueryAsync<Transaction, User, User, Transaction>(sql, (trans, userFrom, userTo) =>
                {
                    trans.UserFrom = userFrom;
                    trans.UserTo = userTo;
                    return trans;
                }, new { IdTransaction = idTransaction }, splitOn: "IdUser,IdUser");

                return tran.First();
            }
        }
        public static async Task<IEnumerable<Transaction>> GetByUser(int idUser)
        {
            var sql = @"
                SELECT T.IdTransaction
	                , T.IdTransactionType AS TransactionType
	                , T.Amount
	                , T.[Date]
	                , T.Active
	                , UF.IdUser
	                , UF.Email
	                , UF.FullName
	                , UT.IdUser
	                , UT.Email  
	                , UT.FullName
                FROM [Transaction] T
                INNER JOIN [User] UF ON T.IdUserFrom = UF.IdUser
                INNER JOIN [User] UT ON T.IdUserTo = UT.IdUser
                WHERE T.IdUserFrom = @IdUser
                    OR T.IdUserTo = @IdUser";

            using (var db = GetConection())
            {
                return await db.QueryAsync<Transaction, User, User, Transaction>(sql.ToString(), (trans, userFrom, userTo) =>
                {
                    trans.UserFrom = userFrom;
                    trans.UserTo = userTo;
                    return trans;
                }, new { IdUser = idUser }, splitOn: "IdUser,IdUser");
            }
        }
    }
}
