using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Week
    {
        [Key]
        public int Id { get; set; }
        public int WeekNumber { get; set; }
    }
}
