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
    public class WorkTimeController : ControllerBase
    {
        private readonly IAccountManager _accountManager;
        private readonly IWorkTimeManager _workTimeManager;

        public WorkTimeController(IAccountManager accountManager, IWorkTimeManager workTimeManager)
        {
            _accountManager = accountManager;
            _workTimeManager = workTimeManager;
        }

        [HttpGet("WorkTime/{id}")]
        public IActionResult GetByEmpId(int id)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            List<WorkTimeSearchModel> result;
            try
            {
                result = _workTimeManager.GetById(id, email);
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
        [HttpGet("WorkTime/Search/{empId}")]
        public IActionResult SearchByEmpCode(string empId)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            List<WorkTimeSearchModel> result;
            try
            {
                result = _workTimeManager.SeachByCode(empId, email);
                if (result == null || result.Count == 0)
                {
                    return Conflict("Null");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return Conflict("This employee doesnt exist!!!");
            }
        }
        [HttpPost("WorkTime")]
        public IActionResult Add([FromBody]WorkTimeAddModel model)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _workTimeManager.Add(model, email);
                return Ok("Success");
            }
            catch (Exception)
            {
                return Conflict("Error!!!");
            }
        }
        [HttpPut("WorkTime")]
        public IActionResult Update([FromBody]WorkTimeUpdateModel model)
        {
            Request.Headers.TryGetValue("Authorization", out var token);
            string email = _accountManager.GetEmailByToken(token);
            try
            {
                _workTimeManager.Update(model, email);
                return Ok("Success");

            }
            catch (Exception)
            {
                return Conflict("Error!!!");
            }
        }
    }
}