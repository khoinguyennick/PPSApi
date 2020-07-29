using Microsoft.EntityFrameworkCore;
using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPorfolioSystem.Repository.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectPorfolioSystemContext _context;
        private readonly int FINISH_STATUS = 3;
        private readonly int NOT_STARTED = 6;
        private readonly int IN_PROGRESS = 2;

        public ProjectRepository(ProjectPorfolioSystemContext context)
        {
            _context = context;
        }
        public void Add(ProjectAddModel model, string email)
        {

            Project projectExist = _context.Project.FirstOrDefault(p => p.ProjectCompanyId == model.ProjectCompanyId && p.Email == email);
            if(projectExist != null)
            {
                throw new Exception("Project exist");
            }
            DateTime actualEndDate = new DateTime(2000, 1, 1);

            Project project = new Project()
            {
                Email = email,
                Description = model.Description,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                ProjectCompanyId = model.ProjectCompanyId,
                StatusId = NOT_STARTED,
                ActualEndDate = actualEndDate
            };
            _context.Project.Add(project);
            _context.SaveChanges();
        }
        public void Update(ProjectUpdateModel model, string email)
        {
            Project project = _context.Project.FirstOrDefault(p => p.Email == email && p.Id == model.Id);
            if (project == null)
            {
                throw new Exception("Decline!!!");
            }
            project.Description = model.Description;
            project.StartDate = model.StartDate;
            project.EndDate = model.EndDate;
            _context.Project.Update(project);
            _context.SaveChanges();
        }
        public void ChangeStatus(int id, string email, int statusId)
        {
            Project project = _context.Project.FirstOrDefault(p => p.Email == email && p.Id == id);
            if (project == null)
            {
                throw new Exception("Decline!!");
            }
            project.StatusId = statusId;
            if (statusId == FINISH_STATUS)
            {
                project.ActualEndDate = DateTime.Now;
            }
            _context.Update(project);
            _context.SaveChanges();
        }
        public List<ProjectSearchModel> SearchById(string id, string email)
        {
            List<ProjectSearchModel> result = new List<ProjectSearchModel>();
            var models = _context.Project.Where(p => (p.ProjectCompanyId.Contains(id)) && p.Email == email).ToList();
            foreach (var item in models)
            {
                result.Add(new ProjectSearchModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    ProjectCompanyId = item.ProjectCompanyId,
                });
            }
            return result;
        }
        public List<ProjectSearchModel> GetAll(string email)
        {
            List<ProjectSearchModel> result = new List<ProjectSearchModel>();
            var models = _context.Project.Where(p => p.Email == email).ToList();
            foreach (var item in models)
            {
                result.Add(new ProjectSearchModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    ProjectCompanyId = item.ProjectCompanyId,
                });
            }
            return result;
        }
        public ProjectViewModel GetById(string email, int id)
        {
            ProjectViewModel result = null;
            var model = _context.Project.First(p => p.Email == email && p.Id == id);
            if (model.Email == null)
            {
                throw new Exception("Decline!!");
            }
            result = new ProjectViewModel()
            {
                Id = model.Id,
                Description = model.Description,
                ProjectCompanyId = model.ProjectCompanyId,
                ActualEndDate = model.ActualEndDate,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                StatusId = model.StatusId
            };
            return result;
        }
        public void AddEmployeeToProject(string email, int emId, int projectId)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id == emId && email == e.Owner);
            Project project = _context.Project.FirstOrDefault(e => e.Id == projectId && email == e.Email);
            if (employee == null || project == null)
            {
                throw new Exception("Decline!!");
            }
            EmployeeInProject employeeExistProject = _context.EmployeeInProject.FirstOrDefault(e => e.EmployeeId == emId && e.ProjectId == projectId && e.Active == true);
            if (employeeExistProject != null)
            {
                throw new Exception("Already exist!!!");
            }
            EmployeeInProject employeeInProject = new EmployeeInProject()
            {
                Active = true,
                EmployeeId = employee.Id,
                ProjectId = project.Id
            };
            _context.Add(employeeInProject);
            _context.SaveChanges();
        }
        public ProjectStatisticsModel ProjectStatistics(string email)
        {
            ProjectStatisticsModel result = new ProjectStatisticsModel();
            result.InProgress = _context.Project.Where(p => p.StatusId == IN_PROGRESS && p.Email == email).Count();
            result.Finished = _context.Project.Where(p => p.StatusId == FINISH_STATUS && p.Email == email).Count();
            result.All = _context.Project.Where(p => p.Email == email).Count();
            return result;
        }
        public List<ManpowerInProjectModel> ManpowerInProjectModel(string email)
        {
            List<ManpowerInProjectModel> result = new List<ManpowerInProjectModel>();

            List<Project> projects = _context.Project.Include(e => e.EmployeeInProject).Where(p => p.Email == email).ToList();
            foreach(var project in projects)
            {
                int manpower = 0;
                foreach(var empP in project.EmployeeInProject)
                {
                    manpower += _context.Employee.First(e => e.Id == empP.EmployeeId).Manpower;
                }
                result.Add(new ManpowerInProjectModel()
                {
                    Id = project.ProjectCompanyId,
                    Description = project.Description,
                    Manpower = manpower
                });
            }
            result = result.OrderByDescending(r => r.Manpower).ToList();
            return result;
        }
        public List<NewestProjectModel> NewestProject(string email)
        {
            List<NewestProjectModel> result = new List<NewestProjectModel>();
            List<Project> projects = _context.Project.OrderByDescending(o => o.Id).Where(p => p.Email == email).ToList();
            foreach(var item in projects)
            {
                result.Add(new NewestProjectModel() {
                    Id = item.ProjectCompanyId,
                    CreateTime = item.StartDate,
                    Description = item.Description,
                    Status = _context.Status.First(s => s.Id == item.StatusId).Description
                });
            }
            return result;
        }
        public List<BaseModel> GetProjectStatus()
        {
            List<BaseModel> result = new List<BaseModel>();
            List<Status> statuses = _context.Status.Where(s => s.Active == true).ToList();
            foreach(var item in statuses)
            {
                result.Add(new BaseModel() {
                    Id = item.Id,
                    Description = item.Description
                });
            }
            return result;
        }
    }
}
