using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPorfolioSystem.Manager.Implementations
{
    public interface IAccountManager
    {
        void Add(RegisterDto model);
        Task<bool> CreateActiveCodeAsync(string email);
        Task<bool> CheckActiveCodeAsync(string email, string code, string password);
        LoginSuccessViewModel GetAccountByEmail(string email);
        string GetEmailByToken(string token);
        void UpdateProfile(string email, UserInfo model);
        User GetAccountByToken(string token);
    }
}
