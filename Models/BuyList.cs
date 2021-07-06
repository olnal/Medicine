using Medicine.Data;
using Medicines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class BuyList : GeneralList<Buy>
    {
        private readonly RazorPagesContext _context;
        public BuyList(RazorPagesContext context)
        {
            _context = context;
        }

        public override void Add(Buy item)
        {
            _context.Buys.Add(item);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var existing = _context.Buys.Where(t => t.Id == id).FirstOrDefault();
            if (existing != null)
            {
                _context.Buys.Remove(existing);
                _context.SaveChanges();
            }
        }

        public override void Edit(Buy item)
        {
            var existing = _context.Buys.Where(t => t.Id == item.Id).FirstOrDefault();
            if (existing != null)
            {
                existing.Drug = item.Drug;
                existing.Amount = item.Amount;
                existing.Date = item.Date;
                _context.SaveChanges();
            }
        }

        public override Buy Get(int? id)
        {
            return _context.Buys.Where(t => t.Id == id).FirstOrDefault();
        }

        public override List<Buy> GetAll()
        {
            return _context.Buys.ToList();
        }
    }
}
