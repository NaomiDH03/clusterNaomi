﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clusterNaomi.Shared.Entities
{
    public class Store
    {
        public int Id { get; set; }
        [Required] //Esto significa que será un campo requerido, o sea, obligatorio
        [MaxLength(100, ErrorMessage = "El campo{0} debe tener máximo {1} caracteres ")]
        //Nota: El required y MaxLenght solo afecta a la propiedad siguiente, o sea, Flavour
        [Display(Name = "Tienda")]
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Location { get; set; } = null!;

        //Es de agregacion asi que le pasamos los helados
        public List<Icecream> Icecreams { get; set; } = null!;

    }
}
