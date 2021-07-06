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
                            Type = "Пігулка"
                        },
                        new DrugType
                        {
                            Type = "Розчин"
                        },
                        new DrugType
                        {
                            Type = "Ін'єкція"
                        },
                        new DrugType
                        {
                            Type = "Засоби гігієни"
                        },
                        new DrugType
                        {
                            Type = "Інше"
                        },
                        new DrugType
                        {
                            Type = "Мазь"
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
                            Name = "Медопрам",
                            Type = context.DrugTypes.Where(t => t.Type == "Пігулка").FirstOrDefault(),
                            Price = 151.38,
                            Count = 20
                        },
                         new Drug
                         {
                             Id = 2,
                             Name = "Діклофенак",
                             Type = context.DrugTypes.Where(t => t.Type == "Мазь").FirstOrDefault(),
                             Price = 99.34,
                             Count = 5
                         }
                         ,
                         new Drug
                         {
                             Id = 3,
                             Name = "Підгузники",
                             Type = context.DrugTypes.Where(t => t.Type == "Засоби гігієни").FirstOrDefault(),
                             Price = 99.34,
                             Count = 5
                         },
                         new Drug
                         {
                             Id = 4,
                             Name = "Вода мінеральна",
                             Type = context.DrugTypes.Where(t => t.Type == "Інше").FirstOrDefault(),
                             Price = 99.34,
                             Count = 5
                         },
                         new Drug
                         {
                             Id = 5,
                             Name = "Флюколд",
                             Type = context.DrugTypes.Where(t => t.Type == "Пігулка").FirstOrDefault(),
                             Price = 99.34,
                             Count = 5
                         },
                         new Drug
                         {
                             Id = 6,
                             Name = "Триакутан",
                             Type = context.DrugTypes.Where(t => t.Type == "Мазь").FirstOrDefault(),
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
                            Amount = 15,
                            Date = new DateTime(2021, 03, 05)
                        },
                         new Order
                         {
                             Drug = context.Drugs.Where(t => t.Id == 2).FirstOrDefault(),
                             Amount = 100,
                             Date = new DateTime(2021, 03, 07)
                         },
                         new Order
                         {
                             Drug = context.Drugs.Where(t => t.Id == 1).FirstOrDefault(),
                             Amount = 20,
                             Date = new DateTime(2021, 03, 07)
                         }
                    );
                    context.SaveChanges();
                }
                if (!context.Buys.Any())
                {
                    context.Buys.AddRange(
                        new Buy
                        {
                            Drug = context.Drugs.Where(t => t.Id == 4).FirstOrDefault(),
                            Amount = 1,
                            Date = new DateTime(2020, 03, 05)
                        },
                         new Buy
                         {
                             Drug = context.Drugs.Where(t => t.Id == 2).FirstOrDefault(),
                             Amount = 1,
                             Date = new DateTime(2020, 03, 07)
                         },
                         new Buy
                         {
                             Drug = context.Drugs.Where(t => t.Id == 1).FirstOrDefault(),
                             Amount = 2,
                             Date = new DateTime(2020, 03, 07)
                         }
                    );
                    context.SaveChanges();
                }

            }

        }
    }
}