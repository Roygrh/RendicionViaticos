using RendicionViaticos.Models.Integrix;
using RendicionViaticos.Models.Rendicion;
using RendicionViaticos.Services.Repository;

namespace RendicionViaticos.Services.Unit
{
    public interface IUnitOfWork
    {
        IRepository<rendidos_cab> StatementHeaders { get; }
        IRepository<rendidos_det> StatementDetails { get; }
        IRepository<rendidos_usuarios> StatementUsers { get; }
        IRepository<gasto_fppe> FppPayments { get; }
        IRepository<V_CPAGO> IntegrixPayments { get; }
        void Commit();
        void RollBack();
    }
}
