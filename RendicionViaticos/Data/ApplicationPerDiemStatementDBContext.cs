using Microsoft.EntityFrameworkCore;
using RendicionViaticos.Models.Rendicion;

namespace RendicionViaticos.Data
{
    public class ApplicationPerDiemStatementDBContext : DbContext
    {
        public ApplicationPerDiemStatementDBContext(DbContextOptions<ApplicationPerDiemStatementDBContext> options) : base(options)
        {

        }
        public DbSet<gasto_fppe> gasto_fppe { get; set; }
        public DbSet<rendidos_cab> rendidos_cab { get; set; }
        public DbSet<rendidos_det> rendidos_det { get; set; }
        public DbSet<rendidos_usuarios> rendidos_usuarios { get; set; }
    }
}
