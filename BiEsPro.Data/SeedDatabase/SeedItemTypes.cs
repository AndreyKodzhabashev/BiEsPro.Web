using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiEsPro.Data.Models.ItemElements;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BiEsPro.Data.SeedDatabase
{
    public class SeedItemTypes : ISeeder
    {
        public async Task SeedAsync(IApplicationBuilder app)
        {
            using (var context = (BiEsProDbContext)app.ApplicationServices.CreateScope().ServiceProvider.GetService(typeof(BiEsProDbContext)))
            {
                if (context.ItemTypes.Any() == false)
                {
                    await context.ItemTypes.AddAsync(new ItemType { Code = "FnPl", Name = "Furniture panel" });
                    await context.ItemTypes.AddAsync(new ItemType { Code = "HW", Name = "Hardware" });
                    await context.ItemTypes.AddAsync(new ItemType { Code = "Acs", Name = "Accessory" });
                    await context.ItemTypes.AddAsync(new ItemType { Code = "Wd", Name = "Real Wood" });
                    await context.ItemTypes.AddAsync(new ItemType { Code = "Cmbl", Name = "Consumalbe" });
                    await context.ItemTypes.AddAsync(new ItemType { Code = "Tl", Name = "Tool" });

                    context.SaveChanges();
                }
            }
        }
    }
}
