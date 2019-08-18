using Npgsql;
using ShelterFinder.Domain.Command;
using ShelterFinder.Domain.Interfaces.Infra;
using System;
using System.Threading.Tasks;

namespace ShelterFinder.Handler.Handler
{
    public class BaseHandler
    {
        protected readonly IUnitOfWork uow;

        public BaseHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Transaction(Func<Task> action)
        {
            using (uow.OpenConnection())
            {
                try
                {
                    uow.BeginTransaction();
                    await action();
                    uow.Commit();
                }
                catch (PostgresException ex)
                {
                    throw ex;
                }
            }
            uow.CloseConnection();
        }
        
        public async Task Transaction(BaseCommand command, Func<Task> action)
        {
            await Transaction(action: action);
        }
    }
}
