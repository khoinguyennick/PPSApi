using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class EmpsWorkTimeInProjectModel
    {
        public int EmpId { get; set; }
        public string EmpCompId { get; set; }
        public string Description { get; set; }
        public double TotalTime { get; set; }
    }
}
