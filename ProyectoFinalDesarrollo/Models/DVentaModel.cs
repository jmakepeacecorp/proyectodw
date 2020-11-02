using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Models
{
    public class DVentaModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //definir autoincremento
        [Display(Name = "CodigoDVenta")] //etiqueta
        public int CodigoDVenta { get; set; }

        [Required]
        [Column(TypeName = "Int")] //tipo integer
        [Display(Name = "CodigoEVenta")] //etiqueta
        public int CodigoEVenta { get; set; }

        [Required]
        [Column(TypeName = "Int")] //tipo integer
        [Display(Name = "CodigoProducto")] //etiqueta
        public int CodigoProducto { get; set; }

        [Required]
        [Column(TypeName = "Int")] //tipo integer
        [Display(Name = "Cantidad")] //etiqueta
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "Decimal")] //tipo Decimal
        [Display(Name = "ValorUnitario")] //etiqueta
        public decimal ValorUnitario { get; set; }

        [Required]
        [Column(TypeName = "Decimal")] //tipo Decimal
        [Display(Name = "ValorTotal")] //etiqueta
        public decimal ValorTotal { get; set; }

        //public virtual EVentaModel EVentaModels { get; set; }
        //public virtual ProductosModel ProductosModels { get; set; }
    }
}
