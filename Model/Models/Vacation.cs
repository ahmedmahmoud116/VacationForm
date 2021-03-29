using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Vacation
    {
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }
        public int Balance { get; set; } //default balance of each vacation type
        //EF create hashset by default and requests have list of each vacation entities in request table
        public ICollection<EmployeeRequest> EmployeeRequest { get; set; }
        //EF create hashset by default and balances have list of each vacation entities in balance table
        public ICollection<EmployeeBalance> EmployeeBalance { get; set; }

    }
}
