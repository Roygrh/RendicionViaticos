using RendicionViaticos.Data;
using RendicionViaticos.Models.Integrix;
using RendicionViaticos.Models.Rendicion;
using RendicionViaticos.Services.Repository;

namespace RendicionViaticos.Services.Unit
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationPerDiemStatementDBContext _perDiemStatementContext;
        private ApplicationIntegrixDBContext _integrixContext;
        private GenericRepository<rendidos_cab> PerDiemStatementHeadersRepository;
        private GenericRepository<rendidos_det> PerDiemStatementDetailsRepository;
        private GenericRepository<rendidos_usuarios> PerDiemStatementUsersRepository;
        private GenericRepository<gasto_fppe> FppPaymentsRepository;
        private IntegrixGenericRepository<V_CPAGO> IntegrixPaymentRepository;

        public UnitOfWork(ApplicationPerDiemStatementDBContext perDiemStatement, ApplicationIntegrixDBContext integrixContext)
        {
            this._perDiemStatementContext = perDiemStatement;
            this._integrixContext = integrixContext;
        }

        IRepository<rendidos_cab> IUnitOfWork.StatementHeaders
        {
            get
            {

                if (this.PerDiemStatementHeadersRepository == null)
                {
                    this.PerDiemStatementHeadersRepository = new GenericRepository<rendidos_cab>(_perDiemStatementContext);
                }
                return PerDiemStatementHeadersRepository;
            }
        }

        IRepository<rendidos_det> IUnitOfWork.StatementDetails
        {
            get
            {

                if (this.PerDiemStatementDetailsRepository == null)
                {
                    this.PerDiemStatementDetailsRepository = new GenericRepository<rendidos_det>(_perDiemStatementContext);
                }
                return PerDiemStatementDetailsRepository;
            }
        }

        IRepository<rendidos_usuarios> IUnitOfWork.StatementUsers
        {
            get
            {

                if (this.PerDiemStatementUsersRepository == null)
                {
                    this.PerDiemStatementUsersRepository = new GenericRepository<rendidos_usuarios>(_perDiemStatementContext);
                }
                return PerDiemStatementUsersRepository;
            }
        }

        IRepository<gasto_fppe> IUnitOfWork.FppPayments
        {
            get
            {

                if (this.FppPaymentsRepository == null)
                {
                    this.FppPaymentsRepository = new GenericRepository<gasto_fppe>(_perDiemStatementContext);
                }
                return FppPaymentsRepository;
            }
        }

        IRepository<V_CPAGO> IUnitOfWork.IntegrixPayments
        {
            get
            {

                if (this.IntegrixPaymentRepository == null)
                {
                    this.IntegrixPaymentRepository = new IntegrixGenericRepository<V_CPAGO>(_integrixContext);
                }
                return IntegrixPaymentRepository;
            }
        }

        public void Commit()
        {
            this._perDiemStatementContext.SaveChanges();
            this._integrixContext.SaveChanges();
        }

        public void RollBack()
        {
            //TODO
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //_context.Dispose();
                    _perDiemStatementContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
