using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPorfolioSystem.Manager.Implementations;
using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;

namespace ProjectPorfolioSystem.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IAccountManager _accountManager;
        private readonly IRoleManager _roleManager;
        public RoleController(IAccountManager accountManager, IRoleManager roleManager)
        {
            _accountManager = accountManager;
            _roleManager = roleManager;
        }
        [Authorize]
        [HttpGet("Roles")]
        public IActionResult GetAll()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            List<BaseModel> result = null;
            try
            {
                result = _roleManager.GetAll(email);
                if (result == null || result.Count() == 0)
                {
                    return Conflict("Null");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return Conflict("Error!!!");
            }
        }
        [Authorize]
        [HttpGet("Roles/{id}")]
        public IActionResult GetById(int id)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            BaseModel result = null;
            try
            {
                result = _roleManager.GetById(id, email);
                if (result == null)
                {
                    return Conflict("Null");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return Conflict("You have no permission to get this role!!!");
            }
        }
        [Authorize]
        [HttpPost("Roles")]
        public IActionResult Add([FromBody]string roleName)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _roleManager.Add(roleName, email);
                return Ok("Success");
            }
            catch (Exception)
            {
                return Conflict("Error!!!");
            }
        }
        [Authorize]
        [HttpPut("Roles")]
        public IActionResult Edit([FromBody]BaseModel model)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                bool check = _roleManager.Edit(model.Id, email, model.Description);
                if (check)
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Error!!!");
                }
            }
            catch (Exception)
            {
                return Conflict("You have no permission to update this Role!!!");
            }
        }
        [Authorize]
        [HttpDelete("Roles/{id}")]
        public IActionResult Delete(int id)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                bool check = _roleManager.Remove(id, email);
                if (check)
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Error!!!");
                }
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}