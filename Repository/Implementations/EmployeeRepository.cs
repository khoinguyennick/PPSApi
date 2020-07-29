using Microsoft.EntityFrameworkCore;
using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPorfolioSystem.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ProjectPorfolioSystemContext _context;
        public EmployeeRepository(ProjectPorfolioSystemContext context)
        {
            _context = context;
        }
        public void Add(EmployeeCreateModel employeeModel, string email)
        {
            EmployeeRole role = _context.EmployeeRole.FirstOrDefault(r => r.Owner == email && r.Id == employeeModel.RoleId);
            if (role == null)
            {
                throw new Exception("No permission!!!");
            }
            Employee checkId = _context.Employee.FirstOrDefault(e => e.EmployeeCompanyId == employeeModel.EmployeeCompanyId && e.Owner == email);
            if (checkId != null)
            {
                throw new Exception("Id Exist!!!");
            }
            Employee employee = new Employee()
            {
                EmployeeCompanyId = employeeModel.EmployeeCompanyId,
                FullName = employeeModel.FullName,
                RoleId = employeeModel.RoleId,
                Owner = email,
                Manpower = employeeModel.Manpower,
                Active = true
            };
            _context.Add(employee);
            _context.SaveChanges();
        }
        public List<EmployeeViewModel> GetAll(string email)
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            List<Employee> employees = _context.Employee.Where(e => e.Owner == email && e.Active).ToList();
            foreach (var item in employees)
            {
                result.Add(new EmployeeViewModel()
                {
                    FullName = item.FullName,
                    Id = item.Id,
                    Manpower = item.Manpower,
                    RoleId = item.RoleId,
                    EmployeeCompanyId = item.EmployeeCompanyId
                });
            }
            return result;
        }
        public EmployeeViewModel GetById(int id, string email)
        {
            EmployeeViewModel result = new EmployeeViewModel();
            Employee employee = _context.Employee.First(e => e.Id == id && e.Owner == email && e.Active);
            if (employee == null)
            {
                return null;
            }
            result = new EmployeeViewModel()
            {
                EmployeeCompanyId = employee.EmployeeCompanyId,
                FullName = employee.FullName,
                Id = employee.Id,
                Manpower = employee.Manpower,
                RoleId = employee.RoleId
            };
            return result;
        }
        public List<EmployeeViewModel> Search(string email, string companyId)
        {
            List<EmployeeViewModel> result = new List<EmployeeViewModel>();
            List<Employee> employees = _context.Employee.Where(e => e.Owner == email && e.Active && e.EmployeeCompanyId.Contains(companyId)).ToList();
            foreach (var item in employees)
            {
                result.Add(new EmployeeViewModel()
                {
                    FullName = item.FullName,
                    Id = item.Id,
                    Manpower = item.Manpower,
                    RoleId = item.RoleId,
                    EmployeeCompanyId = item.EmployeeCompanyId
                });
            }
            return result;
        }
        public void Update(EmployeeViewModel employeeModel, string email)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id == employeeModel.Id && e.Owner == email);
            if (employee == null)
            {
                throw new Exception("No Permission!!!");
            }
            employee.EmployeeCompanyId = employeeModel.EmployeeCompanyId;
            employee.FullName = employeeModel.FullName;
            employee.RoleId = employeeModel.RoleId;
            employee.Manpower = employeeModel.Manpower;
            _context.Update(employee);
            _context.SaveChanges();
        }
        public void Remove(string email, int id)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id == id && e.Owner == email);
            if (employee == null)
            {
                throw new Exception("No Permission!!!");
            }
            employee.Active = false;
            _context.Update(employee);
            _context.SaveChanges();
        }
        public EmployeeStatisticsModel Statistic(string owner)
        {
            EmployeeStatisticsModel result = new EmployeeStatisticsModel();
            result.EmployeeCountInProjects = new List<EmployeeCountInProjectModel>();
            List<Employee> employees = _context.Employee.Where(e => e.Owner == owner).ToList();
            result.TotalManpower = 0;
            result.ManpowerUsing = 0;
            foreach (var item in employees)
            {
                result.TotalManpower += item.Manpower;
                if (item.Active == true)
                {
                    result.ManpowerUsing += item.Manpower;
                }
            }

            List<Project> projects = _context.Project.Include(x => x.EmployeeInProject).Where(p => p.Email == owner).ToList();
            var empTbls = new Dictionary<int, int>();
            foreach (var project in projects)
            {
                foreach (var item in project.EmployeeInProject)
                {
                    if (item.Active)
                    {
                        int oldValue = 0;
                        try
                        {
                            empTbls.TryGetValue(item.EmployeeId, out oldValue);
                        }
                        catch
                        {
                            oldValue = 0;
                        }
                        if (oldValue == 0)
                        {
                            empTbls.Add(item.EmployeeId, 1);
                        }
                        else
                        {
                            empTbls.Remove(item.EmployeeId);
                            empTbls.Add(item.EmployeeId, oldValue + 1);
                        }
                    }
                }
            }

            foreach (var item in empTbls)
            {
                EmployeeCountInProjectModel employeeCountInProjectModel = new EmployeeCountInProjectModel()
                {
                    EmpName = _context.Employee.FirstOrDefault(e => e.Id == item.Key).FullName,
                    ProjectCount = item.Value
                };
                result.EmployeeCountInProjects.Add(employeeCountInProjectModel);
            }
            return result;
        }
        public List<NewestEmployeeModel> NewestEmployee(string owner)
        {
            List<NewestEmployeeModel> result = new List<NewestEmployeeModel>();
            List<Employee> employees = _context.Employee.OrderByDescending(e => e.Id).Where(e => e.Owner == owner).ToList();
            foreach (var item in employees)
            {
                result.Add(new NewestEmployeeModel()
                {
                    EmpName = item.FullName,
                    Role = _context.EmployeeRole.FirstOrDefault(r => r.Id == item.RoleId).Description
                });
            }
            return result;
        }
        public ActiveEmployeeModel ActiveEmployee(string owner)
        {
            ActiveEmployeeModel result = new ActiveEmployeeModel();
            result.ActiveEmployee = _context.Employee.OrderByDescending(e => e.Id).Where(e => e.Owner == owner).Count();
            result.InActiveEmployee = _context.Employee.OrderByDescending(e => e.Id).Where(e => e.Owner == owner && e.Active == false).Count();
            return result;
        }
        public List<BaseModel> NotInProject(int projectId, string owner)
        {
            List<BaseModel> result = new List<BaseModel>();
            Project project = _context.Project.Include(pe => pe.EmployeeInProject).FirstOrDefault(p => p.Email == owner && p.Id == projectId);
            if (project == null)
            {
                throw new Exception("!!!!!!!!!!!");
            }
            List<Employee> employees = _context.Employee.Where(e => (e.Owner == owner)).ToList();
            foreach (var employee in employees)
            {
                bool checkExist = false;
                foreach (var eip in project.EmployeeInProject)
                {
                    if(employee.Id == eip.EmployeeId)
                    {
                        checkExist = true;
                    }
                }
                if (!checkExist)
                {
                    result.Add(new BaseModel() {
                        Id = employee.Id,
                        Description = employee.FullName
                    });
                }
            }
            return result;
        }
    }
}
