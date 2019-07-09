using BiEsPro.Data.Models.ClientElements;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace BiEsPro.Data.SeedDatabase
{
    public class SeedVatSufixes : ISeeder
    {
        public async Task SeedAsync(IApplicationBuilder app)
        {
            using (var context = (BiEsProDbContext)app.ApplicationServices.CreateScope().ServiceProvider.GetService(typeof(BiEsProDbContext)))
            {
                if (context.Colors.Any() == false)
                {
                    await context.VatSufixes.AddAsync(new VatSufix { Name = "NotRegistered" });
                    await context.VatSufixes.AddAsync(new VatSufix { Name = "BG" });
                    await context.VatSufixes.AddAsync(new VatSufix { Name = "CZ" });

                    context.SaveChanges();
                }
            }
        }
    }
}
