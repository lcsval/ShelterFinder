using ShelterFinder.Domain.Command.Shelter;
using ShelterFinder.Domain.Entities;
using ShelterFinder.Domain.Interfaces.Handlers;
using ShelterFinder.Domain.Interfaces.Infra;
using ShelterFinder.Domain.Interfaces.Repositories.Write;
using System;
using System.Collections.Generic;
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

        public async Task<Dictionary<string, string>> Insert(ShelterInsertCommand command)
        {
            try
            {
                var data = command.Validate();
                if (!data.IsValid)
                {
                    HandleErrors(command, data);
                    return command.Notifications;
                }

                await Transaction(command, async () =>
                {
                    await _shelterWriteRepository.Insert(command.Map());
                });

                return command.Notifications;
            }
            catch (Exception ex)
            {
                command.Notifications.Add("Error", ex.Message);
                return command.Notifications;
            }
        }

        public async Task<Dictionary<string, string>> Update(ShelterUpdateCommand command)
        {

            try
            {
                var data = command.Validate();
                if (!data.IsValid)
                {
                    HandleErrors(command, data);
                    return command.Notifications;
                }

                await Transaction(command, async () =>
                {
                    await _shelterWriteRepository.Update(command.Map());
                });

                return command.Notifications;
            }
            catch (Exception ex)
            {
                command.Notifications.Add("Error", ex.Message);
                return command.Notifications;
            }
        }

        public async Task<Dictionary<string, string>> Delete(ShelterDeleteCommand command)
        {

            try
            {
                var data = command.Validate();
                if (!data.IsValid)
                {
                    HandleErrors(command, data);
                    return command.Notifications;
                }

                await Transaction(command, async () =>
                {
                    await _shelterWriteRepository.Delete(command.Id);
                });

                return command.Notifications;
            }
            catch (Exception ex)
            {
                command.Notifications.Add("Error", ex.Message);
                return command.Notifications;
            }
        }

        private static void HandleErrors(ShelterBaseCommand command, FluentValidation.Results.ValidationResult data)
        {
            foreach (var item in data.Errors)
                command.Notifications.Add(item.ErrorCode, item.ErrorMessage);
        }
    }
}
