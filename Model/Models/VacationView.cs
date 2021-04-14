using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class VacationView 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int employeeID { get; set; }
        public String FullName { get; set; }
        public int vacationID { get; set; }
        public String Type { get; set; }
        public int Balance { get; set; }
        public int Used { get; set; }
    }
}
