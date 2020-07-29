using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Repository.Interface
{
    public interface IAccountRepository
    {
        void Add(User account);
        DateTime CheckActiveCode(string email, string code);
        bool CreateActiveCode(string email, string code);
        User GetUser(string email);
        void UpdateProfile(string email,UserInfo model);
    }
}
