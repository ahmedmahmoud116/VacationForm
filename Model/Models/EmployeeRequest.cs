using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Models
{
    public class EmployeeRequest
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int VacationID { get; set; }
        public int Days { get; set; }

        public Employee Employee { get; set; }
        public Vacation Vacation { get; set; }
    }
}
