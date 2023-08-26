using Dapper;
using mercado_dirma_backend.Models;
using System.Linq;
using System.Text;

namespace mercado_dirma_backend.Queries
{
    public class UserQuery : DaoBase
    {
        public static async Task<IEnumerable<User>> GetAll(bool isActive = false)
        {
            string sql = @"SELECT * FRM [User]";

            using (var conn = GetConection())
            {
                try
                {
                    return await conn.QueryAsync<User>(isActive ? sql + " WHERE Active = 1 " : sql);
                }
                catch
                {
                    return null;
                }   
            }
        }

        public static async Task<User> GetById(int IdUser)
        {
            string sql = $"SELECT * FROM [User] WHERE IdUser = {IdUser}";

            using (var conn = GetConection())
            {
                try
                {
                    return await conn.QueryFirstOrDefaultAsync<User>(sql);
                }
                catch
                {
                    return new User(0);
                }
            }
        }
    }
}
