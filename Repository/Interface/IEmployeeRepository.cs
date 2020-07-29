using ProjectPorfolioSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Repository.Interface
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeCreateModel employeeModel, string email);
        List<EmployeeViewModel> GetAll(string email);
        EmployeeViewModel GetById(int id, string email);
        List<EmployeeViewModel> Search(string email, string companyId);
        void Update(EmployeeViewModel employeeModel, string email);
        void Remove(string email, int id);
        EmployeeStatisticsModel Statistic(string owner);
        List<NewestEmployeeModel> NewestEmployee(string owner);
        ActiveEmployeeModel ActiveEmployee(string owner);
        List<BaseModel> NotInProject(int projectId, string owner);
    }
}
