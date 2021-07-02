﻿using Medicine.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Models
{
    public class DrugList : GeneralList<Drug>
    {
        private readonly RazorPagesContext _context;
        public DrugList(RazorPagesContext context)
        {
            _context = context;
        }
        public override void Add(Drug item)
        {
            _context.Drugs.Add(item);
            _context.SaveChanges();
        }
        public override void Delete(int id)
        {
            var existing = _context.Drugs.Where(t => t.Id == id).FirstOrDefault();
            if (existing != null)
            {
                _context.Drugs.Remove(existing);
                _context.SaveChanges();
            }                      
        }

        public override void Edit(Drug item)
        {
            var existing = _context.Drugs.Where(t => t.Id == item.Id).FirstOrDefault();
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Type = item.Type;
                existing.Price = item.Price;
                existing.Count = item.Count;

                _context.SaveChanges();
            }
        }

        public override Drug Get(int? id)
        {
            return _context.Drugs.Where(t => t.Id == id).Include(t => t.Type).FirstOrDefault();
        }

        public override List<Drug> GetAll()
        {
            return _context.Drugs.Include(t => t.Type).ToList();
        }
    }
}
