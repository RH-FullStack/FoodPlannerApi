using Business.IService;
using Data.Contracts;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class RecipeService : IRecipeService
    {
        public readonly RecipeRepository _repository;
        public RecipeService(RecipeRepository repository)
        {
            _repository = repository;
        }

        public Task Update(int recipeId)
        {
            var obj = _repository.GetAll().Where(x => x.Id == recipeId).FirstOrDefault();
            if (obj != null)
            {
                _repository.Update(obj);
            }
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var obj = _repository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            _repository.Delete(obj);
            return Task.CompletedTask;
        }

        public Task<Recipe> CreateRecipe(Recipe recipe)
        {
            return _repository.Create(recipe);
        }

        public List<Recipe> GetAllRecipes()
        {
            return _repository.GetAll().ToList();
        }

        public Recipe GetRecipe(int id)
        {
           return _repository.GetById(id);
        }
    }
}
