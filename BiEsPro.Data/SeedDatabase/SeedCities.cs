using System.Linq;
using System.Threading.Tasks;
using BiEsPro.Data.Models.ClientElements;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BiEsPro.Data.SeedDatabase
{
    public class SeedCities : ISeeder
    {
        public async Task SeedAsync(IApplicationBuilder app)
        {
            using (var context = (BiEsProDbContext)app.ApplicationServices.CreateScope().ServiceProvider.GetService(typeof(BiEsProDbContext)))
            {
                if (context.Cities.Any() == false)
                {
                    await context.Cities.AddAsync(new City { Name = "Sofia" });
                    await context.Cities.AddAsync(new City { Name = "Plovdiv" });
                    await context.Cities.AddAsync(new City { Name = "Varna" });
                    await context.Cities.AddAsync(new City { Name = "Bourgas" });
                    await context.Cities.AddAsync(new City { Name = "Montana" });
                    await context.Cities.AddAsync(new City { Name = "Rouse" });
                    await context.Cities.AddAsync(new City { Name = "Veliko Tarnovo" });

                    context.SaveChanges();
                }
            }
        }
    }
}
