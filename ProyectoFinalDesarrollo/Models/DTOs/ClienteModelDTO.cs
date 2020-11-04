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
        public string NombreCliente { get; set; }

        [Required]
        [Display(Name = "ApellidoCliente")] //etiqueta
        public string ApellidoCliente { get; set; }

        [Required]
        [Display(Name = "Nit")] //etiqueta
        public string Nit { get; set; }

        [Required]
        [Display(Name = "Direccion")] //etiqueta
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "CategoriaCliente")] //etiqueta
        public int CategoriaCliente { get; set; }
    }
}
