using BiEsPro.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BiEsPro.Data
{
    public class BiEsProDbContext : IdentityDbContext<BiEsProUser>
    {
        public BiEsProDbContext()
        {
        }
        public BiEsProDbContext(DbContextOptions<BiEsProDbContext> options):base(options)
        {
        }


    }
}
