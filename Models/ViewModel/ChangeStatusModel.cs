using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class ChangeStatusModel
    {
        public int ProjectId { get; set; }
        public int StatusId { get; set; }
    }

    public class AddEmployeeToProject
    {
        public int ProjectId { get; set; }
        public int EmlpoyeeId { get; set; }
    }
}
