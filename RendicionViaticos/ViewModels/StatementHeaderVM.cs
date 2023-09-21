using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace RendicionViaticos.ViewModels
{
    public class StatementHeaderVM
    {
        public string EJERCICIO { get; set; }
        public string CORRELATIVO { get; set; }
        [Display(Name = "N°C/P")]
        public string NRO_CP { get; set; }
        [Display(Name = "N° SIAF")]
        public string NRO_SIAF { get; set; }
        [Display(Name = "MONTO ENCARGO")]
        public decimal MONTO_ENCARGO { get; set; }
        [Display(Name = "MONTO RENDIDO")]
        public decimal MONTO_RENDIDO { get; set; }
        [Display(Name = "INFORMADO")]
        public decimal MONTO_RENDICION { get; set; }
        public decimal SALDO { get; set; }
        public string ESTADO { get; set; }
        public DateTime FECHA_OPERACION { get; set; }
        public string COD_DIGITADOR { get; set; }
        [Display(Name = "OBS.")]
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
