namespace RendicionViaticos.ViewModels
{
    public class StatementDetailVM
    {
        public string EJERCICIO { get; set; }
        public string CORRELATIVO { get; set; }
        public int NUM_FILA { get; set; }
        public string CODIGO_DOCUMENTO { get; set; }
        public string nro_serie { get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public string COD_GASTO_FPPE { get; set; }
        public string CODIGO_PERSONA { get; set; }
        public string TIPO_IDENTIF { get; set; }
        public DateTime FECHA_DOCUMENTO { get; set; }
        public string DESC_PERSONA { get; set; }
        public decimal IMPORTE { get; set; }
        public decimal BASE_IMPONIBLE { get; set; }
        public decimal VALOR_NGRAV { get; set; }
        public decimal MONTO_IGV { get; set; }
        public decimal OTROS { get; set; }
        public int SELECCIONO { get; set; }
        public string OBSERVA_DET { get; set; }
    }
}
