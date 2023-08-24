using Dapper;
using mercado_dirma_backend.Models;
using System.Text;

namespace mercado_dirma_backend.Queries
{
    public class AvailabilityQuery : DaoBase
    {
        public static async Task<IEnumerable<Availability>> GetAll(bool isActive)
        {
            var sql = new StringBuilder(@"
                SELECT IdAvailability
                    , IdAvailableDay
                    , StartHour
                    , EndHour
                    , Active
                FROM Availability ");

            if (isActive)
            {
                sql.Append(" WHERE Active = 1 ");
            }

            using (var db = GetConection())
            {
                return await db.QueryAsync<Availability>(sql.ToString());
            }
        }
    }
}
