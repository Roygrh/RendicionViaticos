namespace RendicionViaticos.ViewModels
{
    public class VCPaymentVM
    {
        public string EJERCICIO { get; set; }
        public string NUMERO_SIAF { get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public Nullable<DateTime> FECHA_OPERACION { get; set; }
        public string CODIGO_PERSONA { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string NOMBRES { get; set; }
        public string GLOSA { get; set; }
        public string CODIGO_PARTIDA_GASTO { get; set; }
        public string DESC_CODIGO_GASTO { get; set; }
        public decimal IMPORTE_PAT { get; set; }
    }
}
