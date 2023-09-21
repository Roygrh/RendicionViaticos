using Microsoft.EntityFrameworkCore;

namespace RendicionViaticos.Models.Rendicion
{
    [Keyless]
    public class gasto_fppe
    {
        public string EJERCICIO { get; set; }
        public string COD_GASTO_FPPE { get; set; }
        public string DESC_GASTO_FPPE { get; set; }
        public string CODIGO_PARTIDA_GASTO { get; set; }
    }
}
