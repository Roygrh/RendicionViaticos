using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RendicionViaticos.Models.Rendicion
{
    public class rendidos_usuarios
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("COD_DIGITADOR", TypeName = "char(3)")]
        public string COD_DIGITADOR { get; set; }
        public string USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public string DENO_USUARIO { get; set; }
        public string NOM_ENCARGA { get; set; }
    }
}
