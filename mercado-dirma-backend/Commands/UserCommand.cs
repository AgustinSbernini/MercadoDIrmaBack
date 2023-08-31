using Dapper;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.UserDTOs;
using mercado_dirma_backend.Queries;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Transactions;

namespace mercado_dirma_backend.Commands
{
    public class UserCommand : DaoBase
    {
        public static async Task<bool> Insert(UserInsertDTO userdto)
        {
            var sqlUser = @"
                INSERT INTO [User] 
                (Email, FullName, Password, Dni, BirthDate, PhoneNumber, Address)
                OUTPUT INSERTED.IdUser
                VALUES (@Email, @FullName, @Password, @Dni, @BirthDate, @PhoneNumber, @Address)";

            var sqlUserRole = @"INSERT INTO [User_Role] 
                                (IdUser, IdRole)
                                VALUES (@IdUser, @IdRole)";

            using (var db = GetConection())
            {
                using (var tran = db.BeginTransaction())
                {
                    try
                    {
                        int resultUser = await db.ExecuteScalarAsync<int>(sqlUser, new
                        {
                            userdto.Email,
                            userdto.FullName,
                            userdto.Password,
                            userdto.Dni,
                            userdto.BirthDate,
                            userdto.PhoneNumber,
                            userdto.Address
                        }, transaction: tran);

                        var resultUseRole = await db.ExecuteAsync(sqlUserRole, new
                        {
                            IdUser = resultUser,
                            IdRole = Role.Usuario
                        }, transaction: tran); ;

                        tran.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                }               
            }
        }

        public static async Task<bool> Update(UserUpdateDTO user)
        {                    
            var sql = @"UPDATE [User] 
                        SET 
                        Email = @Email
                        , FullName = @FullName
                        , Password = @Password
                        , Dni = @Dni
                        , BirthDate = @BirthDate
                        , PhoneNumber = @PhoneNumber
                        , Address = @Address
                        , UpdateDate = @UpdateDate
                        WHERE IdUser = @IdUser";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new
                {
                    user.IdUser,
                    user.Email,
                    user.FullName,
                    user.Password,
                    user.Dni,
                    user.BirthDate,
                    user.PhoneNumber,
                    user.Address,
                    UpdateDate = DateTime.Now
                }) == 1;
            }
        }

        public static async Task<bool> Delete(int idUser)
        {
            var sql = @"UPDATE [User] 
                        SET 
                        DeletionDate = @DeletionDate
                        , Active = 0
                        WHERE IdUser = @IdUser";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new
                {
                    IdUser = idUser,
                    DeletionDate = DateTime.Now
                }) == 1;
            }
        }
    }
}
