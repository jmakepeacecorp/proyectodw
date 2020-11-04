using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Models.DTOs
{
    public class ClienteModelDTO
    {
        [Display(Name = "CodigoCliente")] //etiqueta
        public int CodigoCliente { get; set; }

        [Required]
        [Display(Name = "NombreCliente")] //etiqueta
        public int NombreCliente { get; set; }

        [Required]
        [Display(Name = "ApellidoCliente")] //etiqueta
        public int ApellidoCliente { get; set; }

        [Required]
        [Display(Name = "Nit")] //etiqueta
        public int Nit { get; set; }

        [Required]
        [Display(Name = "Direccion")] //etiqueta
        public int Direccion { get; set; }

        [Required]
        [Display(Name = "CategoriaCliente")] //etiqueta
        public int CategoriaCliente { get; set; }
    }
}
