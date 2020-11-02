using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Models
{
    public class ClientesVentas:ClientesModel
    {
        [Display(Name ="Fecha Orden")]
        [DataType(DataType.Date)]
        public DateTime FechaVenta { set; get; }
    }
}
