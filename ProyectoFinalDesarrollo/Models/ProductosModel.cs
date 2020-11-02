using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Models
{
    public class ProductosModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //definir autoincremento
        [Display(Name = "CodigoProducto")] //etiqueta
        public int CodigoProducto { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")] //tipo varchar
        [Display(Name = "Descripcion")] //etiqueta
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "Int")] //tipo integer
        [Display(Name = "CodigoProveedor")] //etiqueta
        public int CodigoProveedor { get; set; }

        [Required]
        [Column(TypeName = "Date")] //tipo date
        [Display(Name = "Fecha")] //etiqueta
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "Varchar(25)")] //tipo varchar
        [Display(Name = "UbicacionFisica")] //etiqueta
        public string UbicacionFisica { get; set; }

        [Required]
        [Column(TypeName = "Int")] //tipo integer
        [Display(Name = "ExistenciaMinima")] //etiqueta
        public int ExistenciaMinima { get; set; }

        [Required]
        [Column(TypeName = "Int")] //tipo integer
        [Display(Name = "TipoProducto")] //etiqueta
        public int TipoProducto { get; set; }

        [Required]
        [Column(TypeName = "Decimal")] //tipo Decimal
        [Display(Name = "PrecioUnitario")] //etiqueta
        public int PrecioUnitario { get; set; }

        //public virtual ICollection<DVentaModel> DVentaModels { get; set; }
    }
}
