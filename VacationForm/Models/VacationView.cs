using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationForm.Models
{
    public class VacationView 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public String FullName { get; set; }
        public String Type { get; set; }
        public int Balance { get; set; }
        public int Used { get; set; }
    }
}
