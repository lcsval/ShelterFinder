using Dapper;
using ShelterFinder.Domain.Entities;
using ShelterFinder.Domain.Interfaces.Repositories.Read;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShelterFinder.Infra.Repositories.Read
{
    public class ShelterReadRepository : BaseReadRepository, IShelterReadRepository
    {
        public ShelterReadRepository()
        {
        }

        public async Task<Shelter> GetById(int id)
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryFirstAsync<Shelter>(@"
                    SELECT
                        *
                    FROM
                        shelter
                    WHERE
                        id = @Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<Shelter>> Get()
        {
            using (var connection = GetConnection())
            {
                return await connection.QueryAsync<Shelter>(@"
                    SELECT
                        *
                    FROM
                        shelter");
            }
        }
    }
}
