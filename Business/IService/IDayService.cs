using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Business.IService
{
	public interface IDayService
	{
		public Day GetDay(int id);
		public void DeleteDay(int id);
		public List<Day> GetDaysInWeek(int week);
		public List<Day> GetAllDays();
		public void UpdateDay(Day day);
		public Task CreateDay (Day day);
	}
}
