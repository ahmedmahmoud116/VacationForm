using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class EmployeeBalance
    {
        public EmployeeBalance() { }
        public int ID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int VacationID { get; set; }
        [Required]
        public int Balance { get; set; }
        
        public Employee Employee { get; set; }
        public Vacation Vacation { get; set; }
    }
}
