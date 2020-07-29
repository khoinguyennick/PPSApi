using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPorfolioSystem.Manager.Implementations;
using ProjectPorfolioSystem.Manager.Interface;
using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;

namespace ProjectPorfolioSystem.Controllers.Api
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectPorfolioSystemContext _context;
        private readonly IAccountManager _accountManager;
        private readonly IProjectManager _projectManager;
        public ProjectController(ProjectPorfolioSystemContext context, IAccountManager accountManager, IProjectManager projectManager)
        {
            _context = context;
            _accountManager = accountManager;
            _projectManager = projectManager;
        }
        [HttpPost("Project")]
        public IActionResult Add([FromBody]ProjectAddModel model)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _projectManager.Add(model, email);
                return Ok("Success!!!");
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpPut("Project")]
        public IActionResult Update([FromBody]ProjectUpdateModel model)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _projectManager.Update(model, email);
                return Ok("Success!!!");
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpPut("Project/Status")]
        public IActionResult ChangeStatus([FromBody]ChangeStatusModel model)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _projectManager.ChangeStatus(model.ProjectId, email, model.StatusId);
                return Ok("Success!!!");
            }
            catch (Exception)
            {
                return Conflict("Decline!!!");
            }
        }
        [HttpGet("Project/Company/{projectId}")]
        public IActionResult SearchById(string projectId)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _projectManager.SearchById(projectId, email);
                if (result.Count() == 0 || result == null)
                {
                    return Ok("Empty!!!");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpGet("Project")]
        public IActionResult GetAll()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _projectManager.GetAll(email);
                if (result.Count() == 0 || result == null)
                {
                    return Ok("Empty!!!");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpGet("Project/{id}")]
        public IActionResult GetById(int id)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _projectManager.GetById(email, id);
                if (result == null)
                {
                    return Ok("Empty!!!");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return Conflict("Decline!!!");
            }
        }
        [HttpPost("Project/Employee")]
        public IActionResult AddEmployeeToProject([FromBody]AddEmployeeToProject model)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _projectManager.AddEmployeeToProject(email, model.EmlpoyeeId, model.ProjectId);
                return Ok("Success!!!");
            }
            catch (Exception)
            {
                return Conflict("Decline!!!");
            }
        }
        [HttpGet("Project/Statistics")]
        public IActionResult Newest()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _projectManager.ProjectStatistics(email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpGet("Project/Manpower")]
        public IActionResult ManpowerInProject()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _projectManager.ManpowerInProjectModel(email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpGet("Project/Newest")]
        public IActionResult NewestProject()
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                var result = _projectManager.NewestProject(email);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpGet("Project/Status")]
        public IActionResult Status()
        {
            try
            {
                var result = _projectManager.GetProjectStatus();
                return Ok(result);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}   