using mercado_dirma_backend.Commands;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Business
{
    public class AppointmentBusiness
    {
        public async Task<IEnumerable<Appointment>> GetAll(bool isActive)
        {
            return await AppointmentQuery.GetAll(isActive);
        }
        public async Task<Appointment> GetById(int idAppointment)
        {
            return await AppointmentQuery.GetById(idAppointment);
        }
        public async Task<IEnumerable<Appointment>> GetByUser(int idUser, bool isActive)
        {
            return await AppointmentQuery.GetByUser(idUser, isActive);
        }
        public async Task<bool> Insert(Appointment appointment)
        {
            return await AppointmentCommand.Insert(appointment);
        }
        public async Task<bool> Delete(int idAppointment)
        {
            return await AppointmentCommand.Delete(idAppointment);
        }
        public async Task<bool> Update(Appointment appointment)
        {
            return await AppointmentCommand.Update(appointment);
        }
    }
}
