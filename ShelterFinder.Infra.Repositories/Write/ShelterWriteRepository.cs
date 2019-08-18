using System.Threading.Tasks;
using Dapper;
using ShelterFinder.Domain.Entities;
using ShelterFinder.Domain.Interfaces.Infra;
using ShelterFinder.Domain.Interfaces.Repositories.Write;

namespace ShelterFinder.Infra.Repositories.Write
{
    public class ShelterWriteRepository : BaseWriteRepository, IShelterWriteRepository
    {
        public ShelterWriteRepository(IUnitOfWork uow) : base(uow)
        {

        }

        public async Task Insert(Shelter entity)
        {
            await Connection.ExecuteAsync(@"
                INSERT INTO shelter 
                    (Name, Address, Phone, Gender, Latitude, Longitude)
                VALUES
                    (@Name, @Address, @Phone, @Gender, @Latitude, @Longitude);", entity);
        }

        public async Task Update(Shelter entity)
        {
            await Connection.ExecuteAsync(@"
                UPDATE 
                    shelter
                SET
                    Name = @name,
                    Address = @address,
                    Phone = @phone,
                    Gender = @gender,
                    Latitude = @latitude,
                    Longitude = @longitude
                WHERE
                    Id = @id", entity);
        }

        public async Task Delete(int id)
        {
            await Connection.ExecuteAsync(@"DELETE FROM shelter WHERE Id = @Id", new { Id = id });
        }
    }
}