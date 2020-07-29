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
    public class WorkTimeInProjectRepository : IWorkTimeInProjectRepository
    {
        private readonly ProjectPorfolioSystemContext _context;
        public WorkTimeInProjectRepository(ProjectPorfolioSystemContext context)
        {
            _context = context;
        }

        public double ProjectTotalWorkTime(int projectId, string email)
        {
            double result = 0;
            Project project = _context.Project.Include(eip => eip.EmployeeInProject).FirstOrDefault(p => p.Id == projectId && p.Email == email);
            if (project == null)
            {
                return result;
            }
            foreach (var eip in project.EmployeeInProject)
            {
                List<WorkTimeInProject> workTimeInProject = _context.WorkTimeInProject.Where(w => w.EmployeeInProjectId == eip.Id).ToList();
                foreach (var item in workTimeInProject)
                {
                    result += item.WorkHour;
                }
            }
            return result;
        }
        public List<EmpsWorkTimeInProjectModel> EmpsWorkTimeInProject(int projectId, string email)
        {
            List<EmpsWorkTimeInProjectModel> result = new List<EmpsWorkTimeInProjectModel>();
            Project project = _context.Project.Include(eip => eip.EmployeeInProject).FirstOrDefault(p => p.Id == projectId && p.Email == email);
            foreach (var eip in project.EmployeeInProject)
            {
                double totalwork = 0;
                List<WorkTimeInProject> workTimeInProjects = _context.WorkTimeInProject.Where(w => w.EmployeeInProjectId == eip.Id).ToList();
                foreach (var item in workTimeInProjects)
                {
                    totalwork += item.WorkHour;
                }
                Employee employee = _context.Employee.FirstOrDefault(e => e.Id == eip.EmployeeId);
                result.Add(new EmpsWorkTimeInProjectModel() {
                    Description = employee.FullName,
                    EmpId = employee.Id,
                    EmpCompId = employee.EmployeeCompanyId,
                    TotalTime = totalwork
                });
            }
            return result;
        }
        
        public List<WorkTimeDetailViewModel> WorkTimeDetail(int empId, int projectId, string owner)
        {
            List<WorkTimeDetailViewModel> result = new List<WorkTimeDetailViewModel>();
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id == empId && e.Owner == owner);
            int employeeInProjectId = _context.EmployeeInProject.FirstOrDefault(e => e.ProjectId == projectId && e.EmployeeId == empId).Id;
            List<WorkTimeInProject> workTimeInProjects = _context.WorkTimeInProject.OrderByDescending(o => o.Id).Where(w => w.EmployeeInProjectId == employeeInProjectId).ToList();
            foreach(var item in workTimeInProjects)
            {
                result.Add(new WorkTimeDetailViewModel() {
                    Description = employee.FullName,
                    Id = employee.EmployeeCompanyId,
                    WorkDate = item.WorkDate,
                    WorkTime = item.WorkHour
                });
            }
            return result;
        }
        public void AddWorkTime(int empId, double workTime, int projectId, string owner)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id == empId && e.Owner == owner);
            int employeeInProjectId = _context.EmployeeInProject.FirstOrDefault(e => e.ProjectId == projectId && e.EmployeeId == empId).Id;
            WorkTimeInProject model = new WorkTimeInProject()
            {
                EmployeeInProjectId = employeeInProjectId,
                WorkDate = DateTime.Now,
                WorkHour = workTime
            };
            _context.Add(model);
            _context.SaveChanges();
        }
    }
}
