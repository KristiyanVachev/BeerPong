using System;

namespace BeerPong.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
