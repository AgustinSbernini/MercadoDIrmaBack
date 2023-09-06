using Dapper;
using mercado_dirma_backend.DataAccess;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.RoleDTOs;

namespace mercado_dirma_backend.Queries
{
    public class RoleQuery : DaoBase
    {
        public static async Task<IEnumerable<Models.Role>> GetAll()
        {
            string sql = @"SELECT IdRole, RoleName FROM [Role]";

            using (var conn = GetConection())
            {
                return await conn.QueryAsync<Models.Role>(sql);
            }
        }

        public static async Task<IEnumerable<GetUserRolesDTO>> GetRolesByUser(int idUser)
        {
            string sql = @"
                            SELECT UR.IdUser_Role, U.IdUser, U.FullName, R.IdRole, R.RoleName
                            FROM User_Role UR
                            INNER JOIN [User] U ON UR.IdUser = U.IdUser
                            INNER JOIN [Role] R ON UR.IdRole = R.IdRole
                            WHERE UR.IdUser = @IdUser
                        ";

            using (var conn = GetConection())
            {
                return await conn.QueryAsync<GetUserRolesDTO>(sql, new { IdUser = idUser });
            }
        }
    }
}
