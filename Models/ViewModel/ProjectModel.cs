using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class ProjectViewModel : ProjectAddModel
    {
        public int Id { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int StatusId { get; set; }
    }
    public class ProjectAddModel : ProjectModel
    {
        public string ProjectCompanyId { get; set; }
    }
    public class ProjectUpdateModel : ProjectModel
    {
        public int Id { get; set; }
    }
    public class ProjectModel
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class ProjectSearchModel
    {
        public int Id { get; set; }
        public string ProjectCompanyId { get; set; }
        public string Description { get; set; }
    }

}
