using Medicines.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Data
{
    public class RazorPagesContext : DbContext
    {
        
        public RazorPagesContext(
            DbContextOptions<RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugType> DrugTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
