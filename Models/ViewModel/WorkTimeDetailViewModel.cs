using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class WorkTimeDetailViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime WorkDate { get; set; }
        public double WorkTime { get; set; }
    }

    public class WorkTimeInProjectAddModel
    {
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        public double WorkTime { get; set; }

    }
}
