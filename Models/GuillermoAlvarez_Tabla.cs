using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace GuillermoAlvarez_Examen1P.Models
{
    public class GuillermoAlvarez_Tabla
    {
        [Key]
        public int GA_Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string GA_Nombre { get; set; }

        [SeleccioneUnPlan]
        public bool GA_ClienteTelevisor { get; set; }

        [SeleccioneUnPlan]
        public bool GA_ClieneInternet { get; set; }

        [Range(0.01, 9999.99)]

        [verificarRango(ErrorMessage = "Nuestos planes tienen como valor mínimo 12 dolares")]
        public decimal GA_Precio { get; set;}

        public DateTime GA_Fecha { get; set; }

    }
    public class verificarRango: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            decimal valor = (decimal)value;
            if (valor <= 12)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class SeleccioneUnPlan : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validacion)
        {   
            var plan = (GuillermoAlvarez_Tabla)validacion.ObjectInstance;
            if (plan.GA_ClienteTelevisor == false && plan.GA_ClieneInternet == false)
            {
                return new ValidationResult("Debe seleccionar al menos un plan");
            }
            else if(plan.GA_ClienteTelevisor == true && plan.GA_ClieneInternet == true)
            {
                return new ValidationResult("No puede seleccionar ambos planes");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
