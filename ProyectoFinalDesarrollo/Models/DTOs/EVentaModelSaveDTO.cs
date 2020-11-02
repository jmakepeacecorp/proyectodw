using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Models.DTOs
{
    public class EVentaModelSaveDTO
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //definir autoincremento
        [Display(Name = "CodigoEVenta")] //etiqueta
        public int CodigoEVenta { get; set; }

        [Required]        
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        [Display(Name = "Fecha")] //etiqueta
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "CodigoCliente")] //etiqueta
        public int CodigoCliente { get; set; }
        
        [Required]
        [Display(Name = "TipoDocumento")] //etiqueta
        public int TipoDocumento { get; set; }

        [Required]
        [Display(Name = "Estado")] //etiqueta
        public int Estado { get; set; }

        //public virtual ClientesModel ClientesModel { get; set; }
        //public virtual ICollection<DVentaModel> DVentaModels { get; set; }
    }
}
