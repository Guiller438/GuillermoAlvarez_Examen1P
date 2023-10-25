using System.ComponentModel.DataAnnotations;

namespace GuillermoAlvarez_Examen1P.Models
{
    public class GuillermoAlvarez_Tabla
    {
        [Key]
        public int GA_Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string GA_Nombre { get; set; }

        public bool GA_ClienteTelevisor { get; set; }

        public bool GA_ClieneInternet { get; set; }

        [Range(0.01, 9999.99)]
        public decimal GA_Precio { get; set;}

        public DateTime GA_Fecha { get; set; }

    }
}
