using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Models
{
    public class ProductosVentas:ProductosModel
    {
        public int Cantidad { set; get; }
        public decimal partial { get { return Cantidad * PrecioUnitario; } }
    }
}
