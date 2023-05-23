using Business.IService;
using Data.Contracts;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class IngrediantsService : IIngrediantsService
    {
        private readonly IngrediantsRepository _repository;
        public IngrediantsService(IngrediantsRepository repository)
        {
            _repository = repository;
        }
        public Task<Ingrediants> CreateIngrediant(Ingrediants ingrediant)
        {
            return _repository.CreateIngrediant(ingrediant);
        }

        public void DeleteIngrediant(int ingrediantId)
        {
            _repository.Delete(ingrediantId);
        }

        public List<Ingrediants> GetAllIngrediantsWithRecipeId(int recipeId)
        {
            var list = _repository.GetAllIngrediantsOnRecipe(recipeId).ToList();
            return list;
        }

        public Ingrediants GetIngrediants(int ingrediantId)
        {
            return _repository.GetById(ingrediantId);
        }

        public Task Update(int ingrediantId)
        {
            var obj = _repository.GetAll().Where(x => x.Id == ingrediantId).FirstOrDefault();
            if (obj != null)
            {
                _repository.Update(obj);
            }
            return Task.CompletedTask;
        }
    }
}
