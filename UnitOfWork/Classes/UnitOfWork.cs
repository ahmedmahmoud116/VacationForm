using System;
using Data.DBContexts;
using UnitOfWorks.Interfaces;
using Data.Factory;

namespace UnitOfWorks.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDbFactory dbFactory;
        public VacationContext _context;

        //public IDbFactory DbFactory { get; }
        public UnitOfWork(IDbFactory dbFactory,VacationContext context)
        {
            this.dbFactory = dbFactory;
            this._context = dbFactory.init();
        }

        public IDbFactory DbFactory { get; }
        //public VacationContext context { get; }

        public VacationContext context
        {
            get { return _context == null ? dbFactory.init() : _context; }
        }

        public int Commit()
        {
            return context.SaveChanges();
        }
        public void Dispose() /*to clean up the resources*/
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) /*virtual to allow a method declared in the base class to be override in the derived class*/
        {
            if (disposing)
            {
                context.Dispose();
            }
        }

    }
}
