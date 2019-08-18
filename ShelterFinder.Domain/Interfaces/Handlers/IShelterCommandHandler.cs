using ShelterFinder.Domain.Command.Shelter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShelterFinder.Domain.Interfaces.Handlers
{
    public interface IShelterCommandHandler
    {
        Task<Dictionary<string, string>> Insert(ShelterInsertCommand command);
        Task<Dictionary<string, string>> Update(ShelterUpdateCommand command);
        Task<Dictionary<string, string>> Delete(ShelterDeleteCommand command);
    }
}