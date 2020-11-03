using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoFinalDesarrollo.Models.DTOs
{
    public class ProductoDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo del producto")]
        public int CodigoProducto { get; set; }
        [Required]
        [Display(Name = "Descripcion del producto")]
        public String Descripcion { get; set; }
        [Required]
        [Display(Name = "Codigo del proveedor")]
        public int CodigoProveedor { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        [Required]
        [Display(Name = "Ubicacion del producto")]
        public String UbicacionFisica { get; set; }
        [Required]
        [Display(Name = "Existencia minima del producto")]
        public int ExistenciaMinima { get; set; }
        [Required]
        [Display(Name = "Tipo del producto")]
        public int TipoProducto { get; set; }
    } 
}
