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
    public class IngrediantsRepository : IRepository<Ingrediants>
    {
        private readonly PlannerContext _context;

        public IngrediantsRepository(PlannerContext context)
        {
            _context = context;
        }

        public async Task<Ingrediants> CreateIngrediant(Ingrediants _object)
        {
            var obj = _context.Add<Ingrediants>(_object);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }

        public async Task<Ingrediants> Create(Ingrediants _object)
        {
            _context.Add(_object);
            _context.SaveChanges();
            return _object;
        }


        public List<Ingrediants> GetAll()
        {
            var obj = _context.Ingrediants.ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return new List<Ingrediants>();
            }
        }

        public List<Ingrediants> GetAllIngrediantsOnRecipe(int recipeId)
        {
            var obj = _context.Ingrediants.Where(x => x.RecipeId == recipeId).ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public Ingrediants GetById(int id)
        {
            var obj = _context.Ingrediants.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public void Update(Ingrediants _object)
        {
            var obj = _context.Update<Ingrediants>(_object);
            if (obj != null)
            {
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            _context.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
