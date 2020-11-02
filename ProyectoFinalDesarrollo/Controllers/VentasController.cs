using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using ProyectoFinalDesarrollo.Connection;
using ProyectoFinalDesarrollo.Models;

namespace ProyectoFinalDesarrollo.Controllers
{
    public class VentasController : Controller
    {
        private readonly conn _context;

        public VentasController(conn context)
        {
            _context = context;
        }
        public IActionResult CrearVenta()
        {
            Ventas ventas = new Ventas();
            ventas.Clientes = new ClientesVentas();
            ventas.Productos = new List<ProductosVentas>();
            var list = _context.tbl_ClientesModel.ToList();
            ViewBag.CodigoCliente = new SelectList(list, "CodigoCliente", "NombreCliente");
            return View(ventas);
        }
        [HttpGet]
        public ActionResult AgregarProducto()
        {
            var listp = _context.tbl_ProductosModel.ToList();
            ViewBag.CodigoProducto = new SelectList(listp, "CodigoProducto", "Descripcion");
            return View();
        
        }

        [HttpPost]
        public ActionResult AgregarProducto(ProductosVentas pro,HttpRequest re)
        {
            var ventasx = new Ventas();
            var codproducto = re.ContentLength;
            var producto = _context.tbl_ProductosModel.Find(codproducto);
            pro = new ProductosVentas()
            {
                CodigoProducto = producto.CodigoProducto,
                Descripcion = producto.Descripcion,
                PrecioUnitario = producto.PrecioUnitario,
                Cantidad = 1
            };
            ventasx.Productos.Add(pro);

            var listp = _context.tbl_ProductosModel.ToList();
            var list = _context.tbl_ClientesModel.ToList();
            ViewBag.CodigoCliente = new SelectList(list, "CodigoCliente", "NombreCliente");

            ViewBag.CodigoProducto = new SelectList(listp, "CodigoProducto", "Descripcion");
            return View("CrearVenta",ventasx);

        }

    }
}
