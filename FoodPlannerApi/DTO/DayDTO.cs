using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DayDTO
    {
        public Recipe RecipeId { get; set; }
        public Week WeekId { get; set; }
        public int DayOfTheWeek { get; set; }
        public Week Week { get; internal set; }
    }

    
}
