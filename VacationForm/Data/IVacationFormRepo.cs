using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationForm.Models;
namespace VacationForm.Data
{
    //this is what the app will provide
    interface IVacationFormRepo
    {
        IEnumerable<Employee> GetAppEmployees();

        //return type   name of function
        Employee GetEmployeeByID(int id);
    }
}
