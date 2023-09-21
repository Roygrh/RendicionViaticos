using Microsoft.EntityFrameworkCore;

namespace RendicionViaticos.Models.Rendicion
{
    [Keyless]
    public class rendidos_cab
    {
        public string EJERCICIO { get; set; }
        public string CORRELATIVO { get; set; }
        public string NRO_CP { get; set; }
        public string NRO_SIAF { get; set; }
        public decimal MONTO_ENCARGO { get; set; }
        public decimal MONTO_RENDIDO { get; set; }
        public decimal MONTO_RENDICION { get; set; }
        public decimal SALDO { get; set; }
        public string ESTADO { get; set; }
        public DateTime FECHA_OPERACION { get; set; }
        public string COD_DIGITADOR { get; set; }
        public string OBSERVACION { get; set; }
        public Nullable<DateTime> FECHA_COBRO { get; set; }
        public Nullable<DateTime> FECHA_PROGREND { get; set; }
        public string OBJETO_GASTO { get; set; }
        public string OBSERVA_GASTO { get; set; }
        public Nullable<DateTime> FECHA_RENDICION { get; set; }
        public string NRO_DOC_RENDICION { get; set; }
        public Nullable<DateTime> FECHA_APROBACION { get; set; }
        public Nullable<DateTime> FECHA_REGISTRO { get; set; }
    }
}
