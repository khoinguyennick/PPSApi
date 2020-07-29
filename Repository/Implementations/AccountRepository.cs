using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectPorfolioSystem.Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ProjectPorfolioSystemContext _context;
        public AccountRepository(ProjectPorfolioSystemContext context)
        {
            _context = context;
        }
        public void Add(User account)
        {
            _context.User.Add(account);
            _context.SaveChanges();
        }
        public bool CreateActiveCode(string email, string code)
        {
            User account = _context.User.FirstOrDefault(a => a.Email == email);
            if (account != null)
            {
                account.ActiveCode = code;
                account.CodeCreateTime = DateTime.Now;
                _context.User.Update(account);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public DateTime CheckActiveCode(string email, string code)
        {
            User account = _context.User.FirstOrDefault(a => a.Email == email);
            if (account != null)
            {
                if (account.ActiveCode == code)
                {
                    return account.CodeCreateTime;
                }
            }
            return new DateTime();
        }
        public User GetUser(string email)
        {
            return _context.User.FirstOrDefault( u => u.Email == email);
        }
        public void UpdateProfile(string email,UserInfo model)
        {
            User user = _context.User.FirstOrDefault(u => u.Email == email);
            if (!string.IsNullOrEmpty(model.FullName))
            {
                user.FullName = model.FullName;
            }
            if (!string.IsNullOrEmpty(model.PhoneNumber))
            {
                user.PhoneNumber = model.PhoneNumber;
            }
            if (!string.IsNullOrEmpty(model.Address))
            {
                user.Address = model.Address;
            }
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
