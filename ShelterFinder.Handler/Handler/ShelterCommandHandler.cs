using ShelterFinder.Domain.Command.Shelter;
using ShelterFinder.Domain.Interfaces.Handlers;
using ShelterFinder.Domain.Interfaces.Infra;
using ShelterFinder.Domain.Interfaces.Repositories.Write;
using System;
using System.Threading.Tasks;

namespace ShelterFinder.Handler.Handler
{
    public class ShelterCommandHandler : BaseHandler, IShelterCommandHandler
    {
        readonly IShelterWriteRepository _shelterWriteRepository;

        public ShelterCommandHandler(IUnitOfWork uow,
            IShelterWriteRepository shelterWriteRepository) 
            : base(uow)
        {
            _shelterWriteRepository = shelterWriteRepository;
        }

        public async Task Insert(ShelterCommand command)
        {
            try
            {
                var x = command.Validate();
                if (!x.IsValid)
                    return;

                await Transaction(command, async () =>
                {
                    //var entity = new Shelter();
                    //entity.Name = command.shelter.Name;
                    //entity.Address = command.shelter.Address;
                    //entity.Phone = command.shelter.Phone;
                    //entity.Gender = command.shelter.Gender;
                    //entity.Latitude = command.shelter.Latitude;
                    //entity.Longitude = command.shelter.Longitude;
                    //await _shelterWriteRepository.Insert(entity);

                    await _shelterWriteRepository.Insert(command.shelter.Map());
                });
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }

        public async Task Update(ShelterCommand command)
        {

            try
            {
                var x = command.Validate();
                if (!x.IsValid)
                    return;

                await Transaction(command, async () =>
                {
                    //var entity = new Shelter();
                    //entity.Name = command.shelter.Name;
                    //entity.Address = command.shelter.Address;
                    //entity.Phone = command.shelter.Phone;
                    //entity.Gender = command.shelter.Gender;
                    //entity.Latitude = command.shelter.Latitude;
                    //entity.Longitude = command.shelter.Longitude;
                    //await _shelterWriteRepository.Insert(entity);

                    await _shelterWriteRepository.Update(command.shelter.Map());
                });
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }

        public async Task Delete(ShelterCommand command)
        {

            try
            {
                var x = command.Validate();
                if (!x.IsValid)
                    return;

                await Transaction(command, async () =>
                {
                    //var entity = new Shelter();
                    //entity.Name = command.shelter.Name;
                    //entity.Address = command.shelter.Address;
                    //entity.Phone = command.shelter.Phone;
                    //entity.Gender = command.shelter.Gender;
                    //entity.Latitude = command.shelter.Latitude;
                    //entity.Longitude = command.shelter.Longitude;
                    //await _shelterWriteRepository.Insert(entity);

                    await _shelterWriteRepository.Delete(command.shelter.Id);
                });
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }
    }
}
