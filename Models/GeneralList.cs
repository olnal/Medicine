using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Models
{
    public abstract class GeneralList<T>
    {
        public abstract void Edit(T item);
        public abstract void Delete(int Id);
        public abstract void Get(int Id);
        public abstract List<T> GetAll();
    }
}
