using mercado_dirma_backend.Models;
using mercado_dirma_backend.Models.RoleDTOs;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class RoleBusiness
    {
        public async Task<IEnumerable<Models.Role>> GetAll()
        {
            return await RoleQuery.GetAll();
        }

        public async Task<IEnumerable<GetUserRolesDTO>> GetRolesByUser(int idUser)
        {
            return await RoleQuery.GetRolesByUser(idUser);
        }
    }
}
