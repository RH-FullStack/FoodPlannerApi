using Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IRecipeService
    {
        public List<Recipe> GetAllRecipes();
        public Task Update(int recipeId);
        public Task<Recipe> CreateRecipe(Recipe recipe);
        public Task Delete(int id);
        public Recipe GetRecipe(int id);
    }
}
