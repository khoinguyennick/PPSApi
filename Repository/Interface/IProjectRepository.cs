using ProjectPorfolioSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Repository.Interface
{
    public interface IProjectRepository
    {
        void Add(ProjectAddModel model, string email);
        void Update(ProjectUpdateModel model, string email);
        void ChangeStatus(int id, string email, int statusId);
        List<ProjectSearchModel> SearchById(string id, string email);
        List<ProjectSearchModel> GetAll(string email);
        ProjectViewModel GetById(string email, int id);
        void AddEmployeeToProject(string email, int emId, int projectId);
        ProjectStatisticsModel ProjectStatistics(string email);
        List<ManpowerInProjectModel> ManpowerInProjectModel(string email);
        List<NewestProjectModel> NewestProject(string email);
        List<BaseModel> GetProjectStatus();
    }
}
