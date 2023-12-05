using mercado_dirma_backend.Commands;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class AvailabilityBusiness
    {
        public async Task<IEnumerable<Availability>> GetAll(bool isActive)
        {
            return await AvailabilityQuery.GetAll(isActive);
        }
        public async Task<bool> Insert(Availability availability)
        {
            return await AvailabilityCommand.Insert(availability);
        }
        public async Task<bool> Delete(int idAvailability)
        {
            return await AvailabilityCommand.Delete(idAvailability);
        }
        public async Task<bool> Update(Availability availability)
        {
            return await AvailabilityCommand.Update(availability);
        }
    }
}
