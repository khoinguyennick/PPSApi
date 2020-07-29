using System;
using System.Collections.Generic;

namespace ProjectPorfolioSystem.Models.Data
{
    public partial class EmployeeInProject
    {
        public EmployeeInProject()
        {
            WorkTimeInProject = new HashSet<WorkTimeInProject>();
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public bool Active { get; set; }

        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public ICollection<WorkTimeInProject> WorkTimeInProject { get; set; }
    }
}
