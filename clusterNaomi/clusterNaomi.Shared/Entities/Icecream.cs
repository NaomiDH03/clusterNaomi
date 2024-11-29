using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clusterNaomi.Shared.Entities
{
    internal class Icecream
    {
        public int Id { get; set; } //El ID en automatico es autonumerico y es un key
        [Required] //Esto significa que será un campo requerido, o sea, obligatorio
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres ")]
        //Nota: El required y MaxLenght solo afecta a la propiedad siguiente, o sea, Flavour
        [Display(Name = "Helado" )]
        public string Flavour { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

    }
}
