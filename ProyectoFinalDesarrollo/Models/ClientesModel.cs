using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Models
{
    public class ClientesModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //definir autoincremento
        [Display(Name = "CodigoCliente")] //etiqueta
        public int CodigoCliente { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")] //tipo varchar
        [Display(Name = "NombreCliente")] //etiqueta
        public string NombreCliente { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")] //tipo varchar
        [Display(Name = "ApellidoCliente")] //etiqueta
        public string ApellidoCliente { get; set; }

        [Required]
        [Column(TypeName = "Varchar(25)")] //tipo varchar
        [Display(Name = "Nit")] //etiqueta
        public string Nit { get; set; }

        [Required]
        [Column(TypeName = "Varchar(50)")] //tipo varchar
        [Display(Name = "Direccion")] //etiqueta
        public string Direccion { get; set; }

        [Required]
        [Column(TypeName = "Int")] //tipo integer
        [Display(Name = "CategoriaCliente")] //etiqueta
        public int CategoriaCliente { get; set; }

        //public virtual ICollection<EVentaModel> EVentaModels { get; set; }

    }
}
