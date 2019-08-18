using ShelterFinder.Domain.Entities;
using System.Threading.Tasks;

namespace ShelterFinder.Domain.Interfaces.Repositories.Write
{
    public interface IShelterWriteRepository
    {
        Task Insert(Shelter entity);
        Task Update(Shelter entity);
        Task Delete(int id);
    }
}