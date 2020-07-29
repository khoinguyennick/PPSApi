using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class EmployeeStatisticsModel
    {
        public List<EmployeeCountInProjectModel> EmployeeCountInProjects { get; set; }
        public int TotalManpower { get; set; }
        public int ManpowerUsing { get; set; }
    }

    public class EmployeeCountInProjectModel
    {
        public string EmpName { get; set; }
        public int ProjectCount { get; set; }
    }
    
    public class NewestEmployeeModel
    {
        public string EmpName { get; set; }
        public string Role { get; set; }
    }

    public class ActiveEmployeeModel
    {
        public int ActiveEmployee { get; set; }
        public int InActiveEmployee { get; set; }
    }
}
