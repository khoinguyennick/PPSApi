using System;
using System.Collections.Generic;

namespace ProjectPorfolioSystem.Models.Data
{
    public partial class Project
    {
        public Project()
        {
            EmployeeInProject = new HashSet<EmployeeInProject>();
        }

        public int Id { get; set; }
        public string ProjectCompanyId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }

        public User EmailNavigation { get; set; }
        public Status Status { get; set; }
        public ICollection<EmployeeInProject> EmployeeInProject { get; set; }
    }
}
