using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class ProjectStatisticsModel
    {
        public int InProgress { get; set; }
        public int Finished { get; set; }
        public int All { get; set; }
    }

    public class ManpowerInProjectModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Manpower { get; set; }
    }

    public class NewestProjectModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string Status { get; set; }
    }
}
