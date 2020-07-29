using System;
using System.Collections.Generic;

namespace ProjectPorfolioSystem.Models.Data
{
    public partial class User
    {
        public User()
        {
            EmployeeRole = new HashSet<EmployeeRole>();
            Project = new HashSet<Project>();
        }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ActiveCode { get; set; }
        public DateTime CodeCreateTime { get; set; }
        public bool Avtive { get; set; }

        public ICollection<EmployeeRole> EmployeeRole { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
