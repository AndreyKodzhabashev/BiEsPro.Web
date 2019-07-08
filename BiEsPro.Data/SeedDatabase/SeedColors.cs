using System.Linq;
using System.Threading.Tasks;
using BiEsPro.Data.Models.ItemElements;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BiEsPro.Data.SeedDatabase
{
    public class SeedColors : ISeeder
    {
        public async Task SeedAsync(IApplicationBuilder app)
        {
            using (var context = (BiEsProDbContext)app.ApplicationServices.CreateScope().ServiceProvider.GetService(typeof(BiEsProDbContext)))
            {
                if (context.Colors.Any() == false)
                {
                    await context.Colors.AddAsync(new Color { Code = "Red", Name = "Red" });
                    await context.Colors.AddAsync(new Color { Code = "White", Name = "White" });
                    await context.Colors.AddAsync(new Color { Code = "Blue", Name = "Blue" });
                    await context.Colors.AddAsync(new Color { Code = "Yellow", Name = "Yellow" });
                    await context.Colors.AddAsync(new Color { Code = "Onyx", Name = "Onyx" });
                    await context.Colors.AddAsync(new Color { Code = "Marble", Name = "Marble" });
                    await context.Colors.AddAsync(new Color { Code = "Cherry", Name = "Cherry" });

                    context.SaveChanges();
                }
            }
        }
    }
}
