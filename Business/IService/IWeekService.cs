using Business.Services;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IService
{
    public interface IWeekService
    {
        Week GetWeek(int id);
        List<Week> GetWeeks(List<int> ids);
        Task UpdateWeek(Week week);
        Task DeleteWeek(int id);
        Task CreateWeek(Week week);
        List<Week> GetAllWeeks();
    }
}
