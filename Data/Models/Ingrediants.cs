using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Ingrediants
    {
        [Key]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public Unit MeasuringUnit { get; set; }
    }
    public enum Unit{
        TableSpoon,
        Grams,
        Kilos,
        Dl,
        Ml,
        L

    }
}
