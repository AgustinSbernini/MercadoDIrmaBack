using mercado_dirma_backend.Commands;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class UserBusiness
    {
        public async Task<IEnumerable<User>> GetAll(bool isActive = false)
        {
            return await UserQuery.GetAll(isActive);
        }

        public async Task<User> GetById(int IdUser)
        {
            return await UserQuery.GetById(IdUser);
        }


        public async Task<bool> Insert(int idUser, string email, string fullName, string password, int dni, DateTime birthDate, long phoneNumber, string address, DateTime creationDate, DateTime deletionDate, DateTime updateDate, bool active)
        {
            var user = new User() 
            {
                IdUser = idUser,
                Email = email,
                FullName = fullName,
                Password = password,
                Dni = dni,
                BirthDate = birthDate,
                PhoneNumber = phoneNumber,
                Address = address,
                CreationDate = creationDate,
                DeletionDate = deletionDate,
                UpdateDate = updateDate,
                Active = active,
            };
            return await UserCommand.Insert(user);
        }
    }
}
