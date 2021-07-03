using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public abstract class GeneralList<T>
    {
        public abstract void Add(T item);
        public abstract void Edit(T item);
        public abstract void Delete(int Id);
        public abstract T Get(int? Id);
        public abstract List<T> GetAll();
    }
}
