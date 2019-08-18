using ShelterFinder.Domain.Interfaces.Infra;
using System.Data;

namespace ShelterFinder.Infra.Repositories.Write
{
    public abstract class BaseWriteRepository
    {
        readonly IUnitOfWork uow;

        public BaseWriteRepository(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        protected IDbConnection Connection
        {
            get
            {
                return uow.OpenConnection();
            }
        }
    }
}
