using System;
using Data.DBContexts;
using Data.Factory;

namespace UnitOfWorks.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public VacationContext context { get; }
        public IDbFactory DbFactory { get; }

        int Commit();
    }
}
