using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Model.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email", TypeName = "varchar(254)")]
        public String Email { get; set; }//the question mark means the email is nullable
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        //EF create hashset by default and requests have list of each emplyee entities in request table
        public ICollection<EmployeeRequest> EmployeeRequest { get; set; }
        //EF create hashset by default and requests have list of each emplyee entities in request table
        public ICollection<EmployeeBalance> EmployeeBalance { get; set; }

    }
}
