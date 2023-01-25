using Data.Contracts;
using Data.Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RecipeRepository : IRepository<Recipe>
    {
        private readonly PlannerContext _context;

        public RecipeRepository(PlannerContext context)
        {
            _context = context;
        }

        public async Task<Recipe> Create(Recipe _object)
        {
            var obj = _context.Add<Recipe>(_object);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }

        public void Delete(Recipe _object)
        {
            var obj = _context.Remove<Recipe>(_object);
            if (obj != null)
            {
                _context.SaveChanges();
            }
        }

        public IEnumerable<Recipe> GetAll()
        {
            var obj = _context.Recipes.ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public Recipe GetById(int id)
        {
            var obj = _context.Recipes.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public void Update(Recipe _object)
        {
            var obj = _context.Update<Recipe>(_object);
            if (obj != null)
            {
                _context.SaveChanges();
            }
        }
    }
}
