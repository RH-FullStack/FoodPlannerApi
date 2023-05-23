using Data.Contracts;
using Data.Data;
using Data.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DayRepository : IRepository<Day>
    {
        private readonly PlannerContext _context;
        public DayRepository(PlannerContext context)
        {
            _context = context;
        }
        public async Task<Day> Create(Day _object)
        {
            var obj = _context.Add(_object);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }

        public void Delete(int id)
        {
            _context.Remove(GetById(id));
            _context.SaveChanges();
        }

        public List<Day> GetAll()
        {
            return _context.Days.ToList();

        }

        public Day GetById(int id)
        {
            var obj = _context.Days.FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public void Update(Day _object)
        {
            _context.Update(_object);
            _context.SaveChanges();
        }
    }
}
