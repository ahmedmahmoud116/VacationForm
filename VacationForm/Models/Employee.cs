using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationForm.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public String? Email { get; set; }//the question mark means the email is nullable
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        //EF create hashset by default and requests have list of each emplyee entities in request table
        public ICollection<Request> Requests { get; set; }
        //EF create hashset by default and requests have list of each emplyee entities in request table
        public ICollection<EmployeeBalance> Balances { get; set; }

    }
}
