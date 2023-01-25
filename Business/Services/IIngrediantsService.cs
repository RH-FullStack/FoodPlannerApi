using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IIngrediantsService
    {
        public List<Ingrediants> GetAllIngrediantsWithRecipeId(int recipeId);
        public Task Update(int ingrediantId);
        public Task<Ingrediants> CreateIngrediant(Ingrediants ingrediant, int recipeId);
        public Task DeleteIngrediant(int ingrediantId);
        public Ingrediants GetIngrediants(int ingrediantId);
    }
}
