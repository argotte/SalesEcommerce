using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Country
    {
        public int ID { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Name { get; set; } = null!;

    }
}
