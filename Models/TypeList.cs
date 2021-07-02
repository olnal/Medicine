using Medicine.Data;
using Medicines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class TypeList : GeneralList<DrugType>
    {
        private readonly RazorPagesContext _context;
        public TypeList(RazorPagesContext context)
        {
            _context = context;
        }
        
        public override void Add(DrugType item)
        {
            _context.DrugTypes.Add(item);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var existing = _context.DrugTypes.Where(t => t.Id == id).FirstOrDefault();
            if (existing != null)
            {
                _context.DrugTypes.Remove(existing);
                _context.SaveChanges();
            }
        }

        public override void Edit(DrugType item)
        {
            var existing = _context.DrugTypes.Where(t => t.Id == item.Id).FirstOrDefault();
            if (existing != null)
            {
                existing.Type = item.Type;                
                _context.SaveChanges();
            }
        }

        public override DrugType Get(int? id)
        {
            return _context.DrugTypes.Where(t => t.Id == id).FirstOrDefault();
        }

        public override List<DrugType> GetAll()
        {
            return _context.DrugTypes.ToList();
        }
    }
}
