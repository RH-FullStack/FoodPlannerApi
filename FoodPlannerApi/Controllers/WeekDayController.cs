using Business.IService;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodPlannerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeekDayController : ControllerBase
    {
        private readonly IWeekService _weekService;
        private readonly IDayService _dayService;
        public WeekDayController(IWeekService weekService, IDayService dayService)
        {
            _weekService = weekService;
            _dayService = dayService;
        }

        [HttpPost]
        [Route("createday")]
        public async Task<ActionResult<DayDTO>> CreateDay(DayDTO dayToCreate)
        {
            var day = new Day
            {
                Recipe = dayToCreate.RecipeId,
                DayOfTheWeek = (weekDays)dayToCreate.DayOfTheWeek,
                Week = dayToCreate.Week
            };
           await _dayService.CreateDay(day);

           return Ok();
        }

        [HttpGet]
        [Route("getday")]
        public Day GetDay(int id)
        {
	        var day = _dayService.GetDay(id);
	        return day;
        }

        [HttpGet]
        [Route("getalldays")]
        public List<Day> GetAllDays()
        {
	        return _dayService.GetAllDays();
        }

        [HttpGet]
        [Route("getdaysinweek")]
        public List<Day> GetDaysInWeek(int weekid)
        {
	        return _dayService.GetDaysInWeek(weekid);
        }

        [HttpPost]
        [Route("updateday")]
        public Task UpdateDay(Day dayToUpdate)
        {
            _dayService.UpdateDay(dayToUpdate);
            return Task.CompletedTask;
        }

        [HttpPost]
        [Route("deleteday")]
        public Task DeleteDay(int id)
        {
            _dayService.DeleteDay(id);
            return Task.CompletedTask;
        }

        [HttpPost]
        [Route("createweek")]
        public async Task<ActionResult<WeekDTO>> CreateWeek(WeekDTO weekDTO)
        {
            var week = new Week
            {
                WeekNumber = weekDTO.WeekNumber,
            };
            _weekService.CreateWeek(week);
            return Ok();

        }

        [HttpPost]
        [Route("deleteweek/{weekID}")]
        public async Task<ActionResult> DeleteWeek(int weekID)
        {
            _weekService.DeleteWeek(weekID);
            return Ok();
        }

        [HttpPost]
        [Route("updateweek")]
        public async Task<ActionResult> UpdateWeek(WeekDTO weekDTO)
        {
            var week = new Week
            {
                WeekNumber = weekDTO.WeekNumber,
            };
            _weekService.UpdateWeek(week);
            return Ok();
        }

        [HttpGet]
        [Route("getweek")]
        public Week GetWeek(int id)
        {
            return _weekService.GetWeek(id);
        }

        [HttpGet]
        [Route("getallweeks")]
        public List<Week> GetAllWeeks()
        { 
            return _weekService.GetAllWeeks(); 
        }
    }
}
