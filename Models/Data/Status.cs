using System;
using System.Collections.Generic;

namespace ProjectPorfolioSystem.Models.Data
{
    public partial class Status
    {
        public Status()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}
