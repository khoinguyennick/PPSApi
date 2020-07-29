using System;
using System.Collections.Generic;

namespace ProjectPorfolioSystem.Models.Data
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeInProject = new HashSet<EmployeeInProject>();
            WorkTime = new HashSet<WorkTime>();
        }

        public int Id { get; set; }
        public string EmployeeCompanyId { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public string Owner { get; set; }
        public int Manpower { get; set; }
        public bool Active { get; set; }

        public EmployeeRole Role { get; set; }
        public ICollection<EmployeeInProject> EmployeeInProject { get; set; }
        public ICollection<WorkTime> WorkTime { get; set; }
    }
}
