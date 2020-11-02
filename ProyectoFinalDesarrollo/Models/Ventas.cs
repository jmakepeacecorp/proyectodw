using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Models
{
    public class Ventas
    {
        public ClientesVentas Clientes { set; get; }
        public EVentaModel Encabezado { set; get; }
        public ProductosVentas Titulos { set; get; }
        public List<ProductosVentas> Productos { set; get; }
        
    }
}
