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
    public class WeekRepository : IRepository<Week>
    {
        public readonly PlannerContext _context;
        public WeekRepository(PlannerContext context) 
        {
            _context = context;
        } 
        public async Task<Week> Create(Week _object)
        {
            var obj = _context.Add(_object);
            try
            {
                _context.SaveChanges();

            }
            catch (Exception c)
            {

                throw;
            }
            return obj.Entity;
        }

        public void Delete(int id)
        {
            var week = GetById(id);
            _context.Remove(week);
            _context.SaveChanges();
        }


        public List<Week> GetAll()
        {
            var obj = _context.Weeks.ToList();
            if (obj != null)
            {
                return obj;
            }
            return new List<Week>();
        }

        public Week GetById(int id)
        {
            var obj =  _context.Weeks.FirstOrDefault(x => x.Id == id);
            if (obj != null)
                return obj;

            return null;
        }

        public void Update(Week _object)
        {
            var obj = GetById(_object.Id);
            obj.WeekNumber = _object.WeekNumber;
            _context.Update(obj);
            _context.SaveChanges();
        }

        Week IRepository<Week>.GetById(int id)
        {
            var obj = _context.Weeks.FirstOrDefault(x => x.Id == id);
            return obj;
        }
    }
}
