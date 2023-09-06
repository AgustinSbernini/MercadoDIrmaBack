using mercado_dirma_backend.Models;
using System.Text;
using Dapper;
using mercado_dirma_backend.DataAccess;

namespace mercado_dirma_backend.Queries
{
    public class AppointmentQuery : DaoBase
    {
        public static async Task<IEnumerable<Appointment>> GetAll(bool isActive)
        {
            var sql = new StringBuilder(@"
                SELECT A.IdAppointment 
                    , A.IdAppointmentStatus AS AppointmentStatus
                    , A.Description 
                    , A.AppointmentDate 
                    , A.IdUser 
                    , U.Email
                    , U.FullName
                    , U.Dni
                    , U.BirthDate
                    , U.PhoneNumber
                    , U.Address
                    , U.Active
                FROM Appointment A 
                INNER JOIN [User] U ON A.IdUser = U.IdUser ");

            if (isActive)
            {
                sql.Append(@" WHERE A.IdAppointmentStatus IN (1,3) 
                                AND U.Active = 1");
            }

            using (var db = GetConection())
            {
                return await db.QueryAsync<Appointment, User, Appointment>(sql.ToString(), (appointment, user) =>
                {
                    appointment.User = user;
                    return appointment;
                }, splitOn: "IdUser");
            }
        }

        public static async Task<Appointment> GetById(int idAppointment)
        {
            var sql = new StringBuilder(@"
                SELECT A.IdAppointment 
                    , A.IdAppointmentStatus AS AppointmentStatus
                    , A.Description 
                    , A.AppointmentDate 
                    , A.IdUser 
                    , U.Email
                    , U.FullName
                    , U.Dni
                    , U.BirthDate
                    , U.PhoneNumber
                    , U.Address
                    , U.Active
                FROM Appointment A 
                INNER JOIN [User] U ON A.IdUser = U.IdUser 
                WHERE A.IdAppointment = @IdAppointment");


            using (var db = GetConection())
            {
                var turno = await db.QueryAsync<Appointment, User, Appointment>(sql.ToString(), (appointment, user) =>
                {
                    appointment.User = user;
                    return appointment;
                }, new { IdAppointment = idAppointment }, splitOn: "IdUser");

                return turno.FirstOrDefault();
            }
        }

        public static async Task<IEnumerable<Appointment>> GetByUser(int idUser, bool isActive)
        {
            var sql = new StringBuilder(@"
                SELECT A.IdAppointment 
                    , A.IdAppointmentStatus AS AppointmentStatus
                    , A.Description 
                    , A.AppointmentDate 
                    , A.IdUser 
                    , U.Email
                    , U.FullName
                    , U.Dni
                    , U.BirthDate
                    , U.PhoneNumber
                    , U.Address
                    , U.Active
                FROM Appointment A 
                INNER JOIN [User] U ON A.IdUser = U.IdUser 
                WHERE A.IdUser = @IdUser ");

            if (isActive)
            {
                sql.Append(@" WHERE A.IdAppointmentStatus IN (1,3) ");
            }

            using (var db = GetConection())
            {
                return await db.QueryAsync<Appointment, User, Appointment>(sql.ToString(), (appointment, user) =>
                {
                    appointment.User = user;
                    return appointment;
                }, new { IdUser = idUser }, splitOn: "IdUser");
            }
        }
    }
}
