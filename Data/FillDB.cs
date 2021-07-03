using Medicine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Data
{
    public static class FillDB
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesContext>>()))
            {
                if (!context.DrugTypes.Any())
                {
                    context.DrugTypes.AddRange(
                        new DrugType
                        {
                            Type = "Drug"
                        },
                        new DrugType
                        {
                            Type = "Ointmen"
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.Drugs.Any())
                {
                    context.Drugs.AddRange(
                        new Drug
                        {
                            Id = 1,
                            Name = "Medopram",
                            Type = context.DrugTypes.Where(t => t.Type == "Drug").FirstOrDefault(),
                            Price = 151.38,
                            Count = 20
                        },
                         new Drug
                         {
                             Id = 2,
                             Name = "Diclofenac",
                             Type = context.DrugTypes.Where(t => t.Type == "Ointmen").FirstOrDefault(),
                             Price = 99.34,
                             Count = 5
                         }
                    );
                    context.SaveChanges();
                }

                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(
                        new Order
                        {
                            Drug = context.Drugs.Where(t => t.Id == 1).FirstOrDefault(),
                            Amount = 1,
                            Date = new DateTime(2021, 03, 05)
                        },
                         new Order
                         {
                             Drug = context.Drugs.Where(t => t.Id == 2).FirstOrDefault(),
                             Amount = 1,
                             Date = new DateTime(2021, 03, 07)
                         },
                         new Order
                         {
                             Drug = context.Drugs.Where(t => t.Id == 1).FirstOrDefault(),
                             Amount = 2,
                             Date = new DateTime(2021, 03, 07)
                         }
                    );
                    context.SaveChanges();
                }

            }

        }
    }
}

