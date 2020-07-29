using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPorfolioSystem.Manager.Implementations;
using ProjectPorfolioSystem.Manager.Interface;
using ProjectPorfolioSystem.Models.ViewModel;

namespace ProjectPorfolioSystem.Controllers.Api
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class WorkTimeInProjectController : ControllerBase
    {
        private readonly IAccountManager _accountManager;
        private readonly IWorkTimeInProjectManager _workTimeInProjectManager;
        public WorkTimeInProjectController(IAccountManager accountManager, IWorkTimeInProjectManager workTimeInProjectManager)
        {
            _accountManager = accountManager;
            _workTimeInProjectManager = workTimeInProjectManager;
        }

        [HttpGet("WorkTimeInProject/TotalWorkTime/{id}")]
        public IActionResult TotalWorkTime(int id)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _workTimeInProjectManager.ProjectTotalWorkTime(id ,email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("WorkTimeInProject/Employees/{id}")]
        public IActionResult Employees(int id)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _workTimeInProjectManager.EmpsWorkTimeInProject(id, email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("WorkTimeInProject/WorkTimeDetail/{projectId}/{empId}")]
        public IActionResult WorkTimeDetail(int projectId, int empId)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _workTimeInProjectManager.WorkTimeDetail(empId, projectId, email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("WorkTimeInProject/WorkTime")]
        public IActionResult WorkTime([FromBody]WorkTimeInProjectAddModel model)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _workTimeInProjectManager.AddWorkTime(model.EmpId, model.WorkTime, model.ProjectId, email);
                return Ok("Success!!!");
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}