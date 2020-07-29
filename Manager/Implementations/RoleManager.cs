using ProjectPorfolioSystem.Manager.Implementations;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Manager.Interface
{
    public class RoleManager : IRoleManager
    {
        private readonly IEmployeeRoleRepository _companyRoleRepository;
        public RoleManager(IEmployeeRoleRepository companyRoleRepository)
        {
            _companyRoleRepository = companyRoleRepository;
        }

        public List<BaseModel> GetAll(string email)
        {
            return _companyRoleRepository.GetAll(email);
        }
        public BaseModel GetById(int id, string email)
        {
            return _companyRoleRepository.GetById(id, email);
        }
        public void Add(string roleName, string email)
        {
             _companyRoleRepository.Add(roleName, email);
        }
        public bool Edit(int id, string email, string description)
        {
            return _companyRoleRepository.Edit(id, email, description);
        }
        public bool Remove(int id, string email)
        {
            return _companyRoleRepository.Remove(id, email);
        }
    }
}
