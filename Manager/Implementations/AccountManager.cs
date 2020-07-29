using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ProjectPorfolioSystem.Manager.Implementations;
using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using ProjectPorfolioSystem.Utils.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPorfolioSystem.Manager.Interface
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUtils _utils;
        private readonly TimeSpan expiredTime = new TimeSpan(0, 0, 5, 0);
        private readonly ProjectPorfolioSystemContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuation;
        public AccountManager(IAccountRepository accountRepository, IUtils utils, ProjectPorfolioSystemContext context, UserManager<IdentityUser> userManager, IConfiguration configuation)
        {
            _accountRepository = accountRepository;
            _context = context;
            _utils = utils;
            _userManager = userManager;
            _configuation = configuation;
        }
        public void Add(RegisterDto model)
        {
            User account = new User()
            {
                Email = model.Email,
                FullName = model.FullName,
                ActiveCode = "",
                CodeCreateTime = DateTime.Now,
                Avatar = "https://i.ibb.co/wNPsP1C/default.jpg",
                Address = model.Address,
                Avtive = true,
                PhoneNumber = model.PhoneNumber
            };
            _accountRepository.Add(account);

        }
        public async Task<bool> CreateActiveCodeAsync(string email)
        {
            string randomCode = _utils.CreateCode();
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com", // set your SMTP server name here
                Port = 587, // Port 
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("ppsystem2020@gmail.com", "899a1902f")
            };

            using (var message = new MailMessage("ppsystem2020@gmail.com", email)
            {
                Subject = "Your Active Code In Project Porfolio System:",
                Body = "Active code will Expires in 5 minutes: " + randomCode
            })
            {
                await smtpClient.SendMailAsync(message);
            }

            return _accountRepository.CreateActiveCode(email, randomCode);
        }
        public async Task<bool> CheckActiveCodeAsync(string email, string code, string password)
        {
            DateTime codeCreateTime = _accountRepository.CheckActiveCode(email, code);
            codeCreateTime += expiredTime;
            if (codeCreateTime >= DateTime.Now && codeCreateTime != new DateTime())
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == email);
                await _userManager.RemovePasswordAsync(appUser);
                var rs = await _userManager.AddPasswordAsync(appUser, password);
                if (rs.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }
        public string GetEmailByToken(string token)
        {
            try
            {
                if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    token = token.Substring("Bearer ".Length).Trim();
                }
                var tokenString = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

                var userName = tokenString.Claims.First(claim => claim.Type == "email").Value;

                var account = _context.User.FirstOrDefault(_ => _.Email.Equals(userName));
                if (account != null)
                {
                    return account.Email;
                }
                return null;
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }

        }
        public User GetAccountByToken(string token)
        {
            try
            {
                if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    token = token.Substring("Bearer ".Length).Trim();
                }
                var tokenString = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;

                var userName = tokenString.Claims.First(claim => claim.Type == "email").Value;

                var account = _context.User.FirstOrDefault(p => p.Email.Equals(userName));
                if (account != null)
                {
                    return account;
                }
                return null;
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }

        }
        public LoginSuccessViewModel GetAccountByEmail(string email)
        {
            User account = _context.User.FirstOrDefault(a => a.Email == email);
            AspNetUsers user = _context.AspNetUsers.FirstOrDefault(u => u.Email == email);
            string roleId = _context.AspNetUserRoles.FirstOrDefault(r => r.UserId == user.Id).RoleId;
            string role = _context.AspNetRoles.FirstOrDefault(r => r.Id == roleId).Name;
            LoginSuccessViewModel result = new LoginSuccessViewModel()
            {
                FullName = account.FullName,
                ImagePath = account.Avatar,
                Role = role,
                Address = account.Address,
                PhoneNumber = account.PhoneNumber
            };
            return result;
        }
        public void UpdateProfile(string email, UserInfo model)
        {
            _accountRepository.UpdateProfile(email, model);
        }
    }
}
