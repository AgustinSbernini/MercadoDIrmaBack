using Dapper;
using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;

namespace mercado_dirma_backend.Commands
{
    public class AppointmentCommand : DaoBase
    {
        public static async Task<bool> Insert(Appointment appointment)
        {
            var sql = @"
                INSERT INTO Appointment 
                    (IdAppointmentStatus, IdUser, Description, AppointmentDate)
                VALUES (@AppointmentStatus, @IdUser, @Description, @AppointmentDate)";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new
                {
                    appointment.AppointmentStatus,
                    appointment.User.IdUser,
                    appointment.Description,
                    appointment.AppointmentDate
                }) == 1;
            }
        }
        public static async Task<bool> Delete(int idAppointment)
        {
            var sql = @"
                UPDATE Appointment
                SET IdAppointmentStatus = 2
                WHERE IdAppointment = @IdAppointment";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { IdAppointment = idAppointment }) == 1;
            }
        }
        public static async Task<bool> Update(Appointment appointment)
        {
            var sql = @"
                UPDATE Appointment 
                SET 
                    IdAppointmentStatus = @AppointmentStatus
                    , IdUser = @IdUser
                    , Description = @Description
                    , AppointmentDate = @AppointmentDate
                WHERE IdAppointment = @IdAppointment";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new
                {
                    appointment.IdAppointment,
                    appointment.AppointmentStatus,
                    appointment.User.IdUser,
                    appointment.Description,
                    appointment.AppointmentDate
                }) == 1;
            }
        }
    }
}
