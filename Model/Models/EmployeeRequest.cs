using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class EmployeeRequest
    {
        public int ID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int VacationID { get; set; }
        [Required]
        public int Days { get; set; }

        public Employee Employee { get; set; }
        public Vacation Vacation { get; set; }
    }
}
