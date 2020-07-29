using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Manager.Implementations
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Add(EmployeeCreateModel employeeModel, string email)
        {
            try
            {
                _employeeRepository.Add(employeeModel, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<EmployeeViewModel> GetAll(string email)
        {
            try
            {
                return _employeeRepository.GetAll(email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public EmployeeViewModel GetById(int id, string email)
        {
            try
            {
                return _employeeRepository.GetById(id, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<EmployeeViewModel> Search(string email, string companyId)
        {
            try
            {
                return _employeeRepository.Search(email, companyId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(EmployeeViewModel employeeModel, string email)
        {
            try
            {
                _employeeRepository.Update(employeeModel, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Remove(string email, int id)
        {
            try
            {
                _employeeRepository.Remove(email, id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmployeeStatisticsModel Statistic(string email)
        {
            try
            {
                EmployeeStatisticsModel result = _employeeRepository.Statistic(email);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<NewestEmployeeModel> NewestEmployee(string owner)
        {
            try
            {
                return _employeeRepository.NewestEmployee(owner);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActiveEmployeeModel ActiveEmployee(string owner)
        {
            try
            {
                return _employeeRepository.ActiveEmployee(owner);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<BaseModel> NotInProject(int projectId, string owner)
        {
            try
            {
                return _employeeRepository.NotInProject(projectId, owner);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
