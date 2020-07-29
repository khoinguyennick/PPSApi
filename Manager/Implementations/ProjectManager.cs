using ProjectPorfolioSystem.Manager.Interface;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Manager.Implementations
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectManager(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void Add(ProjectAddModel model, string email)
        {
            try
            {
                _projectRepository.Add(model, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(ProjectUpdateModel model, string email)
        {
            try
            {
                _projectRepository.Update(model, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void ChangeStatus(int id, string email, int statusId)
        {
            try
            {
                _projectRepository.ChangeStatus(id, email, statusId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<ProjectSearchModel> SearchById(string id, string email)
        {
            return _projectRepository.SearchById(id, email);
        }
        public List<ProjectSearchModel> GetAll(string email)
        {
            return _projectRepository.GetAll(email);
        }
        public ProjectViewModel GetById(string email, int id)
        {
            var result = _projectRepository.GetById(email, id);
            return result;
        }
        public void AddEmployeeToProject(string email, int emId, int projectId)
        {
            try
            {
                _projectRepository.AddEmployeeToProject(email, emId, projectId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public ProjectStatisticsModel ProjectStatistics(string email)
        {
            try
            {
                return _projectRepository.ProjectStatistics(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ManpowerInProjectModel> ManpowerInProjectModel(string email)
        {
            try
            {
                return _projectRepository.ManpowerInProjectModel(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<NewestProjectModel> NewestProject(string email)
        {
            try
            {
                return _projectRepository.NewestProject(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<BaseModel> GetProjectStatus()
        {
            try
            {
                return _projectRepository.GetProjectStatus();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
