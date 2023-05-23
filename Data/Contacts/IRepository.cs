using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IRepository < T >
    {
        public List<T> GetAll();
        public Task <T> Create (T _object);
        public void Update (T _object);
        public void Delete (int id);
        public T GetById(int id);

    }
}
