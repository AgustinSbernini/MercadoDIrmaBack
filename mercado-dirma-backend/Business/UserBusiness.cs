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
    }
}
