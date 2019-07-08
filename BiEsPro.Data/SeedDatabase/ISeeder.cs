using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;

namespace BiEsPro.Data.SeedDatabase
{
    public interface ISeeder
    {
        Task SeedAsync(IApplicationBuilder app);
    }
}
