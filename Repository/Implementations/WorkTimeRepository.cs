using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPorfolioSystem.Repository.Implementations
{
    public class WorkTimeRepository : IWorkTimeRepository
    {
        private readonly ProjectPorfolioSystemContext _context;
        public WorkTimeRepository(ProjectPorfolioSystemContext context)
        {
            _context = context;
        }
        public void Add(WorkTime model, string email)
        {
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id == model.EmployeeId && e.Owner == email);
            if(employee == null)
            {
                throw new Exception("Decline!!");
            }
            _context.Add(model);
            _context.SaveChanges();
        }
        public void Update(WorkTime model, string email)
        {
            WorkTime workTime = _context.WorkTime.FirstOrDefault(w => w.Id == model.Id);
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id == workTime.EmployeeId && e.Owner == email);
            if (employee == null)
            {
                throw new Exception("Decline!!");
            }
            workTime.WorkHour = model.WorkHour;
            _context.Update(workTime);
            _context.SaveChanges();
        }
        public List<WorkTime> SeachByCode(string empId, string email)
        {
            List<WorkTime> result = new List<WorkTime>();
            Employee employee = _context.Employee.FirstOrDefault(e => (e.EmployeeCompanyId.ToUpper()).Equals(empId.ToUpper()) && e.Owner == email);
            if(employee == null)
            {
                throw new Exception("Decline!!");
            }
            result = _context.WorkTime.Where(w => w.EmployeeId == employee.Id).ToList();
            return result;
        }
        public List<WorkTime> GetById(int empId, string email)
        {
            List<WorkTime> result = new List<WorkTime>();
            Employee employee = _context.Employee.FirstOrDefault(e => e.Id==empId && e.Owner == email);
            if (employee == null)
            {
                throw new Exception("Decline!!");
            }
            result = _context.WorkTime.OrderByDescending(o => o.WorkDate).Where(w => w.EmployeeId == employee.Id).ToList();
            return result;
        }
    }
}
