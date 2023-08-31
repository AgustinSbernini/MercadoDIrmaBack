using Dapper;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.UserDTOs;
using System.Linq;
using System.Text;

namespace mercado_dirma_backend.Queries
{
    public class UserQuery : DaoBase
    {
        public static async Task<IEnumerable<User>> GetAll(bool isActive = false)
        {
            string sql = @"SELECT * FROM [User]";

            using (var conn = GetConection())
            {
                return await conn.QueryAsync<User>(isActive ? sql + " WHERE Active = 1 " : sql);
            }
        }

        public static async Task<User> GetById(int IdUser)
        {
            string sql = $"SELECT * FROM [User] WHERE IdUser = {IdUser}";

            using (var conn = GetConection())
            {
                return await conn.QueryFirstOrDefaultAsync<User>(sql);
            }
        }
    }
}
