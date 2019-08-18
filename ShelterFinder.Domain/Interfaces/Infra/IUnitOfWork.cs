using System;

namespace ShelterFinder.Domain.Interfaces.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        dynamic OpenConnection();
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseConnection();
    }
}
