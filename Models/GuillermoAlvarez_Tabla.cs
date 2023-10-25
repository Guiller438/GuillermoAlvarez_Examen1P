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

        [SeleccioneUnPlan(ErrorMessage = "Debes seleccionar al menos una")]
        public bool GA_ClienteTelevisor { get; set; }

        [SeleccioneUnPlan(ErrorMessage = "Debes seleccionar al menos una")]
        public bool GA_ClieneInternet { get; set; }

        [Range(0.01, 9999.99)]

        [verificarRango(ErrorMessage = "Nuestos planes tienen como valor mínimo 12 dolares")]
        public decimal GA_Precio { get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [MayorEdad(ErrorMessage = "Debe ser mayor de edad para poder registrarse")]
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

    public class MayorEdad  : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (value is DateTime fechaNacimiento)
            {
                var edad = DateTime.Today.Year - fechaNacimiento.Year;
                if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }
                return edad >= 18;
            }
            return false; 
        }
    }
}
