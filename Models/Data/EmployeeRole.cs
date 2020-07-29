using System;
using System.Collections.Generic;

namespace ProjectPorfolioSystem.Models.Data
{
    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string Owner { get; set; }

        public User OwnerNavigation { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
