using System;
using System.Collections.Generic;

namespace ProjectPorfolioSystem.Models.Data
{
    public partial class WorkTimeInProject
    {
        public int Id { get; set; }
        public int EmployeeInProjectId { get; set; }
        public DateTime WorkDate { get; set; }
        public double WorkHour { get; set; }

        public EmployeeInProject EmployeeInProject { get; set; }
    }
}
