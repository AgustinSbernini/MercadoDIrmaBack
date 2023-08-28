using Dapper;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.UserDTOs;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Commands
{
    public class UserCommand : DaoBase
    {
        public static async Task<bool> Insert(UserInsertDTO user)
        {
            var sql = @"
                INSERT INTO [User] 
                (Email, FullName, Password, Dni, BirthDate, PhoneNumber, Address)
                VALUES (@Email, @FullName, @Password, @Dni, @BirthDate, @PhoneNumber, @Address)";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new
                {
                    user.Email,
                    user.FullName,
                    user.Password,
                    user.Dni,
                    user.BirthDate,
                    user.PhoneNumber,
                    user.Address
                }) == 1;
            }
        }
    }
}
