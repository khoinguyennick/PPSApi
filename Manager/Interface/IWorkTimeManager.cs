using ProjectPorfolioSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Manager.Interface
{
    public interface IWorkTimeManager
    {
        void Add(WorkTimeAddModel model, string email);
        void Update(WorkTimeUpdateModel model, string email);
        List<WorkTimeSearchModel> SeachByCode(string empId, string email);
        List<WorkTimeSearchModel> GetById(int empId, string email);
    }
}
