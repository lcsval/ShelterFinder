using ShelterFinder.Domain.Command.Shelter;
using System.Threading.Tasks;

namespace ShelterFinder.Domain.Interfaces.Handlers
{
    public interface IShelterCommandHandler
    {
        Task Insert(ShelterCommand command);
        Task Update(ShelterCommand command);
        Task Delete(ShelterCommand command);
    }
}
