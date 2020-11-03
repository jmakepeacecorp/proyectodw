using System;
using ProyectoFinalDesarrollo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.UI.WebControls.WebParts;

namespace ProyectoFinalDesarrollo.Repository.iRepository
{
    public interface iProductoRepository
    {
        ICollection<ProductosModel> GetProductoModels();
        ProductosModel GetProducto(int CodigoProducto);
        bool CreaProducto(ProductosModel producto);
        bool UpdateProducto(ProductosModel producto);
        bool DeleteProducto(ProductosModel producto);
        bool GuardarProducto();
    }
}
