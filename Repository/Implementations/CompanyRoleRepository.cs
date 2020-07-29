using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPorfolioSystem.Repository.Implementations
{
    public class EmployeeRoleRepository: IEmployeeRoleRepository
    {
        private readonly ProjectPorfolioSystemContext _context;
        public EmployeeRoleRepository(ProjectPorfolioSystemContext context)
        {
            _context = context;
        }

        public List<BaseModel> GetAll(string email)
        {
            List<BaseModel> result = new List<BaseModel>();
            List<EmployeeRole> models = _context.EmployeeRole.Where(c => c.Owner == email && c.Active).ToList();
            foreach (var item in models)
            {
                result.Add(new BaseModel()
                {
                    Description = item.Description,
                    Id = item.Id
                });
            }
            return result;
        }
        public BaseModel GetById(int id, string email)
        {
            BaseModel result = null;
            EmployeeRole model = _context.EmployeeRole.First(c => c.Owner == email && c.Id == id && c.Active);
            result = new BaseModel()
            {
                Id = model.Id,
                Description = model.Description
            };
            return result;
        }
        public void Add(string roleName, string email)
        {
            EmployeeRole model = new EmployeeRole()
            {
                Owner = email,
                Description = roleName,
                Active = true
            };
            _context.Add(model);
            _context.SaveChanges();
        }
        public bool Edit(int id, string email, string description)
        {
            EmployeeRole model = _context.EmployeeRole.First(r => r.Id == id && r.Owner == email);
            if(model == null)
            {
                return false;
            }
            model.Description = description;
            _context.Update(model);
            _context.SaveChanges();
            return true;
        }
        public bool Remove(int id, string email)
        {
            EmployeeRole model = _context.EmployeeRole.First(r => r.Id == id && r.Owner == email && r.Active);
            Employee employee = _context.Employee.FirstOrDefault(e => e.RoleId == model.Id);
            if(employee != null)
            {
                throw new Exception("Some Employee is in " + model.Description.ToUpper() + ". Please update again!!!");
            }
            if (model == null)
            {
                return false;
            }
            model.Active = false;
            _context.Update(model);
            _context.SaveChanges();
            return true;
        }
    }
}
