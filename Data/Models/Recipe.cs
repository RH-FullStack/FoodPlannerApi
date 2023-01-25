using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Howto { get; set; }
        public string? Picture { get; set; }
        public string? FinalProduct { get; set; }
        public List<Ingrediants> Ingrediants { get; set; }
    }
}
