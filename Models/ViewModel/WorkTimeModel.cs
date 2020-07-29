using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class WorkTimeViewModel : WorkTimeAddModel
    {
        public int Id { get; set; }
    }
    public class WorkTimeAddModel
    {
        public int EmployeeId { get; set; }
        public double WorkHour { get; set; }
    }
    public class WorkTimeUpdateModel
    {
        public int Id { get; set; }
        public double WorkHour { get; set; }
    }
    public class WorkTimeSearchModel : WorkTimeViewModel
    {
        public DateTime WorkDate { get; set; }
    }
}
