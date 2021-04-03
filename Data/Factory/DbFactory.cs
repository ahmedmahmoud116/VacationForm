using Data.DBContexts;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
using Pomelo.EntityFrameworkCore.MySql;
using Data.Factory;

namespace Data.Factory
{
    public class DbFactory : IDbFactory
    {
        private VacationContext _context;
        public VacationContext context { 
            get
            {
                return _context;
            }
        }
        public VacationContext init()
        {
            if(context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<VacationContext>();
                string mySqlConnectionStr = "server=localhost; port=3306; database=vacationtask; user=root; password=; Persist Security Info=False; Connect Timeout=300";
                optionsBuilder.UseMySql(mySqlConnectionStr);

                _context= new VacationContext(optionsBuilder.Options);
                return _context;
            }

            return context;
        }
    }
}
