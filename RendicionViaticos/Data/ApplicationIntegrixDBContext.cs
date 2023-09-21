using Microsoft.EntityFrameworkCore;
using RendicionViaticos.Models.Integrix;

namespace RendicionViaticos.Data
{
    public class ApplicationIntegrixDBContext : DbContext
    {
        public ApplicationIntegrixDBContext(DbContextOptions<ApplicationIntegrixDBContext> options) : base(options)
        {

        }

        public DbSet<V_CPAGO> V_CPAGO { get; set; }
    }
}
