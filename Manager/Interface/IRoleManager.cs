using ProjectPorfolioSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Manager.Implementations
{
    public interface IRoleManager
    {
        List<BaseModel> GetAll(string email);
        BaseModel GetById(int id, string email);
        void Add(string roleName, string email);
        bool Edit(int id, string email, string description);
        bool Remove(int id, string email);
    }
}
