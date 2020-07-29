using ProjectPorfolioSystem.Manager.Interface;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Manager.Implementations
{
    public class WorkTimeInProjectManager : IWorkTimeInProjectManager
    {
        private readonly IWorkTimeInProjectRepository _workTimeInProjectRepository;

        public WorkTimeInProjectManager(IWorkTimeInProjectRepository workTimeInProjectRepository)
        {
            _workTimeInProjectRepository = workTimeInProjectRepository;
        }

        public double ProjectTotalWorkTime(int projectId, string email)
        {
            try
            {
                return _workTimeInProjectRepository.ProjectTotalWorkTime(projectId, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<EmpsWorkTimeInProjectModel> EmpsWorkTimeInProject(int projectId, string email)
        {
            try
            {
                return _workTimeInProjectRepository.EmpsWorkTimeInProject(projectId, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<WorkTimeDetailViewModel> WorkTimeDetail(int empId, int projectId, string owner)
        {
            try
            {
                return _workTimeInProjectRepository.WorkTimeDetail(empId, projectId, owner);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AddWorkTime(int empId, double workTime, int projectId, string owner)
        {
            try
            {
                _workTimeInProjectRepository.AddWorkTime(empId, workTime, projectId, owner);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
