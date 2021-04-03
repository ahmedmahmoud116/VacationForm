using System;
using System.Collections.Generic;
using System.Text;
using Data.DBContexts;

namespace Data.Factory
{
    public interface IDbFactory
    {
        public VacationContext context { get; }

        public VacationContext init();

    }
}
