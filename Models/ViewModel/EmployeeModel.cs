using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class EmployeeCreateModel
    {
        public string EmployeeCompanyId { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public int Manpower { get; set; }
    }
    public class EmployeeViewModel : EmployeeCreateModel
    {
        public int Id { get; set; }
    }
}
