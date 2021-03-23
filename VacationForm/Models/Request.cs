﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationForm.Models
{
    public class Request
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int VacationID { get; set; }
        public int Days { get; set; }

        public Employee Employee { get; set; }
        public Vacation Vacation { get; set; }
    }
}
