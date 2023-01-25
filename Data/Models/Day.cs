using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }
        public Week Week { get; set; }
        public weekDays DayOfTheWeek { get; set; }

    }

    public enum weekDays
    {
        monday,
        tuesday,
        wednesday,
        thuesday,
        friday,
        saturday,
        sunday,
        
    }
}
