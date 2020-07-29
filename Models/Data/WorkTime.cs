using System;
using System.Collections.Generic;

namespace ProjectPorfolioSystem.Models.Data
{
    public partial class WorkTime
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime WorkDate { get; set; }
        public double WorkHour { get; set; }

        public Employee Employee { get; set; }
    }
}
