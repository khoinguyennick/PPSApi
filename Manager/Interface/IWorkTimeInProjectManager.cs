using ProjectPorfolioSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Manager.Interface
{
    public interface IWorkTimeInProjectManager
    {
        double ProjectTotalWorkTime(int projectId, string email);
        List<EmpsWorkTimeInProjectModel> EmpsWorkTimeInProject(int projectId, string email);
        List<WorkTimeDetailViewModel> WorkTimeDetail(int empId, int projectId, string owner);
        void AddWorkTime(int empId, double workTime, int projectId, string owner);
    }
}
