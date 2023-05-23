using Business.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories;

namespace Business.Services
{
    public class DayService : IDayService
    {
	    public readonly DayRepository _dayRepository;
	    public DayService(DayRepository dayRepository)
	    {
		    _dayRepository = dayRepository;
	    }
	    public Day GetDay(int id)
	    {
		    return _dayRepository.GetById(id);
	    }

	    public void DeleteDay(int id)
	    {
		    _dayRepository.Delete(id);
	    }

	    public List<Day> GetDaysInWeek(int week)
	    {
		   return _dayRepository.GetDaysInWeek(week);
	    }

	    public List<Day> GetAllDays()
	    {
		    return _dayRepository.GetAll();
	    }

	    public void UpdateDay(Day day)
	    {
		    _dayRepository.Update(day);
	    }

	    public Task CreateDay(Day day)
	    {
			var obj = _dayRepository.Create(day);
			return obj;
	    }
    }
}
