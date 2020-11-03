using System;
using System.Collections.Generic;
using ProyectoFinalDesarrollo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.UI.WebControls.WebParts;
using ProyectoFinalDesarrollo.Repository.iRepository;
using ProyectoFinalDesarrollo.Connection;

namespace ProyectoFinalDesarrollo.Repository
{
    public class ProductoRepository : iProductoRepository
    {
        private readonly conn _db;
        public ProductoRepository(conn db)
        {
            _db = db;
        }
        public bool CreaProducto(ProductosModel producto)
        {
            _db.tbl_ProductosModel.Add(producto);
            return GuardarProducto();
        }
        public bool DeleteProducto(ProductosModel producto)
        {
            _db.tbl_ProductosModel.Remove(producto);
            return GuardarProducto();
        }
        public ProductosModel GetProducto(int pCodigoProducto)
        {
            return _db.tbl_ProductosModel.FirstOrDefault(p => p.CodigoProducto == pCodigoProducto);
        }
        public ICollection<ProductosModel> GetProductoModels()
        {
            return _db.tbl_ProductosModel.OrderBy(p => p.CodigoProducto).ToList();
        }
        public bool UpdateProducto(ProductosModel producto)
        {
            _db.tbl_ProductosModel.Update(producto);
            return GuardarProducto();
        }
        public bool GuardarProducto()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}