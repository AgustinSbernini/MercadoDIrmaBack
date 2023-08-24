using mercado_dirma_backend.Models;
using mercado_dirma_backend.Queries;
using Dapper;

namespace mercado_dirma_backend.Commands
{
    public class AvailabilityCommand : DaoBase
    {
        public static async Task<bool> Insert(Availability availability)
        {
            var sql = @"
                INSERT INTO Availability 
                    (IdAvailableDay, StartHour, EndHour, Active)
                VALUES (@IdAvailableDay, @StartHour, @EndHour, 1)";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new 
                { 
                    availability.IdAvailability, 
                    availability.IdAvailableDay,
                    availability.StartHour,
                    availability.EndHour
                }) == 1;
            }
        }
        public static async Task<bool> Delete(int idAvailability)
        {
            var sql = @"
                UPDATE Availability
                SET Active = 0 
                WHERE IdAvailability = @IdAvailability";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new { IdAvailability = idAvailability }) == 1;
            }
        }
        public static async Task<bool> Update(Availability availability)
        {
            var sql = @"
                UPDATE Availability 
                SET IdAvailableDay = @IdAvailableDay
                    , StartHour = @StartHour
                    , EndHour = @EndHour
                    , Active = @Active
                WHERE IdAvailability = @IdAvailability";

            using (var db = GetConection())
            {
                return await db.ExecuteAsync(sql, new
                {
                    availability.IdAvailability,
                    availability.IdAvailableDay,
                    availability.StartHour,
                    availability.EndHour,
                    availability.Active
                }) == 1;
            }
        }
    }
}
