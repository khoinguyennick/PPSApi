using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using ProjectPorfolioSystem.Manager.Implementations;
using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Utils.Interface;

namespace ProjectPorfolioSystem.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUtils _utils;
        private readonly IAccountManager _accountManager;
        private readonly ProjectPorfolioSystemContext _context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration, IUtils utils, IAccountManager accountManager, ProjectPorfolioSystemContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _utils = utils;
            _accountManager = accountManager;
            _context = context;
        }


        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        [HttpPost("Account/Auth")]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                LoginSuccessViewModel success = _accountManager.GetAccountByEmail(model.Email);
                success.Token = _utils.GenerateJwtToken(model.Email, appUser, success.ImagePath, success.Role, success.Address, success.PhoneNumber);
                return success;
            }
            else
            {
                return Conflict("Invalid email or password!!!");
            }
        }
        [HttpPost("Account")]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                try
                {
                    _accountManager.Add(model);
                }
                catch (Exception e)
                {
                    return Conflict(e.Message);
                }
                await _signInManager.SignInAsync(user, false);
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                return Ok("Success!!");
            }
            else
            {
                return Conflict(result.Errors);
            }
        }
        [HttpPost("Account/Code")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody]string email)
        {
            bool createActiveCode = await _accountManager.CreateActiveCodeAsync(email);
            if (createActiveCode)
            {
                return Ok("Success");
            }
            return Conflict("Invalid Email");
        }
        [HttpPut("Account/Password")]
        public async Task<IActionResult> EditPasswordAsync([FromBody] EditPasswordViewModel info)
        {
            var appUser = _userManager.Users.SingleOrDefault(u => u.Email == info.Email);
            var check = await _userManager.ChangePasswordAsync(appUser, info.OldPassword, info.NewPassword);
            if (check.Succeeded)
            {
                return Ok("Success");
            }
            return Conflict("Invalid Infomation!!!");
        }
        [HttpPut("Account/PasswordByCode")]
        public async Task<IActionResult> ChangePasswordByCode([FromBody] ForgotPasswordDto model)
        {
            if (await _accountManager.CheckActiveCodeAsync(model.Email, model.Code, model.Password))
            {
                return Ok("Success");
            }
            return Conflict("Invalid Code or Expired Time!!");
        }
        [HttpPut("Account/Image")]
        [EnableCors("AllowAllHeaders")]
        [Authorize]
        public async Task<IActionResult> UploadImage(IFormFile pictures)
        {
            string uri = "";
            try
            {
                Request.Headers.TryGetValue("Authorization", out var token);
                string email = _accountManager.GetEmailByToken(token);
                var abb = pictures;
                var pictureName = $"{email}{Path.GetExtension(pictures.FileName)}";
                string connectionString = "DefaultEndpointsProtocol=https;AccountName=cs1100320008fffce60;AccountKey=dJWONx/tF0HqzafLAm90h7zgXEsUXcPBDCL5gfBbJ71RgHBzpl3pHZ86yPxg12MP4+9XBJkq2d4NYZJuuf0kOg==;EndpointSuffix=core.windows.net";
                string containerName = "ppsystem-blob";
                BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
                // Get a reference to a blob
                BlobClient blob = container.GetBlobClient(pictureName);
                blob.DeleteIfExists();
                // Open the file and upload its data
                using (Stream file = pictures.OpenReadStream())
                {
                    blob.Upload(file);
                }
                uri = blob.Uri.AbsoluteUri;
                User account = _context.User.FirstOrDefault(a => a.Email == email);
                account.Avatar = uri;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Conflict("Something went wrong!!! " + ex.Message);
            }
            return Ok("Success");
        }
        [Authorize]
        [HttpGet("Account/Profile")]
        public IActionResult GetById()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            try
            {
                User result = _accountManager.GetAccountByToken(token);
                if (result == null)
                {
                    return Conflict("Empty!!!");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return Conflict("You have no permission to get this profile!!!");
            }
        }
        [HttpPut("Account/Information")]
        [Authorize]
        public IActionResult EditProfile(UserInfo model)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _accountManager.UpdateProfile(email, model);
                return Ok("Success");
            }
            catch (Exception)
            {
                return Conflict("An error occurred. Please try again!!!");
            }
        }
    }
}