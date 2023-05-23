using Business.IService;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class WeekService : IWeekService
    {
        public readonly WeekRepository _repository;
        public WeekService(WeekRepository repository) 
        {
            _repository = repository;
        }

        public Task CreateWeek(Week week)
        {
            var obj = _repository.Create(week);
            return obj;
        }

        public Task DeleteWeek(int id)
        {
            _repository.Delete(id);
            return Task.CompletedTask;
        }

        public List<Week> GetAllWeeks()
        {
            return _repository.GetAll();
        }

        public Week GetWeek(int id)
        {
            var week = _repository.GetById(id);
            return week;
        }

        public List<Week> GetWeeks(List<int> ids)
        {
            var obj = _repository.GetAll();
            return obj;
        }

        public Task UpdateWeek(Week week)
        {
            _repository.Update(week);
            return Task.CompletedTask;
        }
    }
}
