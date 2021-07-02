using Medicine.Data;
using Medicines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class OrderList : GeneralList<Order>
    {
        private readonly RazorPagesContext _context;
        public OrderList(RazorPagesContext context)
        {
            _context = context;
        }

        public override void Add(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public override void Delete(int id)
        {
            var existing = _context.Orders.Where(t => t.Id == id).FirstOrDefault();
            if (existing != null)
            {
                _context.Orders.Remove(existing);
                _context.SaveChanges();
            }
        }

        public override void Edit(Order item)
        {
            var existing = _context.Orders.Where(t => t.Id == item.Id).FirstOrDefault();
            if (existing != null)
            {
                existing.Drug = item.Drug;
                existing.Amount = item.Amount;
                existing.Date = item.Date;
                _context.SaveChanges();
            }
        }

        public override Order Get(int? id)
        {
            return _context.Orders.Where(t => t.Id == id).FirstOrDefault();
        }

        public override List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }
    }
}
