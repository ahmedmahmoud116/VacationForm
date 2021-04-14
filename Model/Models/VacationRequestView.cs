using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model.Models
{
    public class VacationRequestView
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int employeeID { get; set; }
        public String FullName { get; set; }
        public int vacationID { get; set; }
        public String Type { get; set; }
        public int Days { get; set; }
    }
}
