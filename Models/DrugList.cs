using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Models
{
    public class DrugList<Drug> : GeneralList<T>
    {
        public override void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Edit(T item)
        {
            throw new NotImplementedException();
        }

        public override void Get(int Id)
        {
            throw new NotImplementedException();
        }

        public override List<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
