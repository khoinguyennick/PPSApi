using ProjectPorfolioSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Repository.Interface
{
    public interface IWorkTimeRepository
    {
        void Add(WorkTime model, string email);
        void Update(WorkTime model, string email);
        List<WorkTime> SeachByCode(string empId, string email);
        List<WorkTime> GetById(int empId, string email);
    }
}
