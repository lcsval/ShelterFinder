using ShelterFinder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShelterFinder.Domain.Interfaces.Repositories.Read
{
    public interface IShelterReadRepository
    {
        Task<Shelter> GetById(int id);
        Task<IEnumerable<Shelter>> Get();
    }
}
