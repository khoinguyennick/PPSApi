using ProjectPorfolioSystem.Manager.Interface;
using ProjectPorfolioSystem.Models.Data;
using ProjectPorfolioSystem.Models.ViewModel;
using ProjectPorfolioSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Manager.Implementations
{
    public class WorkTimeManager : IWorkTimeManager
    {
        private readonly IWorkTimeRepository _workTimeRepository;

        public WorkTimeManager(IWorkTimeRepository workTimeRepository)
        {
            _workTimeRepository = workTimeRepository;
        }

        public void Add(WorkTimeAddModel model, string email)
        {
            WorkTime workTime = new WorkTime()
            {
                WorkDate = DateTime.Now,
                EmployeeId = model.EmployeeId,
                WorkHour = model.WorkHour
            };
            try
            {
                _workTimeRepository.Add(workTime, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(WorkTimeUpdateModel model, string email)
        {
            WorkTime workTime = new WorkTime()
            {
                WorkHour = model.WorkHour,
                Id = model.Id
            };
            try
            {
                _workTimeRepository.Update(workTime, email);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<WorkTimeSearchModel> SeachByCode(string empId, string email)
        {
            List<WorkTimeSearchModel> result = new List<WorkTimeSearchModel>();
            try
            {
                List<WorkTime> models = _workTimeRepository.SeachByCode(empId, email);
                foreach (var item in models)
                {
                    result.Add(new WorkTimeSearchModel()
                    {
                        EmployeeId = item.EmployeeId,
                        Id = item.Id,
                        WorkDate = item.WorkDate,
                        WorkHour = item.WorkHour
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
        public List<WorkTimeSearchModel> GetById(int empId, string email)
        {
            List<WorkTimeSearchModel> result = new List<WorkTimeSearchModel>();
            try
            {
                List<WorkTime> models = _workTimeRepository.GetById(empId, email);
                foreach (var item in models)
                {
                    result.Add(new WorkTimeSearchModel()
                    {
                        EmployeeId = item.EmployeeId,
                        Id = item.Id,
                        WorkDate = item.WorkDate,
                        WorkHour = item.WorkHour
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;
        }
    }
}
