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
    [Route("api/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ProjectPorfolioSystemContext _context;
        private readonly IAccountManager _accountManager;
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(ProjectPorfolioSystemContext context, IAccountManager accountManager, IEmployeeManager employeeManager)
        {
            _context = context;
            _accountManager = accountManager;
            _employeeManager = employeeManager;
        }
        [Authorize]
        [HttpGet("Employees")]
        public IActionResult GetAll()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                List<EmployeeViewModel> result = _employeeManager.GetAll(email);
                if(result == null || result.Count == 0)
                {
                    return Conflict("Empty!!!");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [Authorize]
        [HttpGet("Employees/{id}")]
        public IActionResult GetById(int id)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                EmployeeViewModel result = _employeeManager.GetById(id, email);
                if (result == null)
                {
                    return Conflict("Empty!!!");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return Conflict("You have no permission to get this Employee!!!");
            }
        }
        [Authorize]
        [Route("Employees")]
        [HttpPost]
        public IActionResult Add([FromBody]EmployeeCreateModel employee)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _employeeManager.Add(employee, email);
                return Ok("Success!!!");
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [Authorize]
        [HttpGet("Employees/Search")]
        public IActionResult Search(string employeeId)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                List<EmployeeViewModel> result = _employeeManager.Search(email, employeeId);
                if (result == null || result.Count == 0)
                {
                    return Conflict("Empty!!!");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [Authorize]
        [HttpPut("Employees")]
        public IActionResult Update(EmployeeViewModel employee)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _employeeManager.Update(employee, email);
                return Ok("Success!!!");
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [Authorize]
        [HttpDelete("Employees/{id}")]
        public IActionResult Delete(int id)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _employeeManager.Remove(email, id);
                return Ok("Success!!!");
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [Authorize]
        [HttpGet("Employees/Statistics")]
        public IActionResult Statistics()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _employeeManager.Statistic(email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [Authorize]
        [HttpGet("Employees/Newest")]
        public IActionResult Newest()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _employeeManager.NewestEmployee(email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [Authorize]
        [HttpGet("Employees/InActive")]
        public IActionResult InActive()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _employeeManager.ActiveEmployee(email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [Authorize]
        [HttpGet("Employees/NotInProject/{projectId}")]
        public IActionResult NotInProject(int projectId)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _employeeManager.NotInProject(projectId, email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}