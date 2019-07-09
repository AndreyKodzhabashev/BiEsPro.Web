using BiEsPro.Data;
using BiEsPro.Data.SeedDatabase;
using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BiEsPro.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder builder { get; set; }


        public static void UseSeeder(this IApplicationBuilder app)
        {
            var types = Assembly
                       .GetAssembly(typeof(BiEsProDbContext))
                       .GetTypes()
                       .Where(p => typeof(ISeeder).IsAssignableFrom(p) && !p.IsInterface & p.IsClass)
                       .ToList();

            foreach (var type in types)
            {
                var inst = (ISeeder)Activator.CreateInstance(type);

                Task.Run(async () => await inst.SeedAsync(app)).GetAwaiter().GetResult();

            }

        }
    }
}
