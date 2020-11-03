using ProyectoFinalDesarrollo.Repository.iRepository;
using ProyectoFinalDesarrollo.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalDesarrollo.Models.DTOs;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
// System.Web.Mvc;

namespace ProyectoFinalDesarrollo.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoControllerAPI : Controller
    {
        private readonly iProductoRepository _ctProductos;
        private readonly IMapper _mapper;

        private ProductoControllerAPI(iProductoRepository ctoProductos, IMapper mapper)
        {
            _ctProductos = ctoProductos;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListaProductos()
        {
            var nListaProducto = _ctProductos.GetProductoModels();
            var nListaProductoDTO = new List<ProductoDTO>();

            foreach (var nLista in nListaProducto)
            {
                nListaProductoDTO.Add(_mapper.Map<ProductoDTO>(nLista));
            }
            return Ok(nListaProductoDTO);
        }
        [HttpGet("{nCodigoProducto:int}", Name = "GetProductoByCodigo")]
        public IActionResult GetProductoByCodigo(int nCodigoProducto)
        {

            var RegistroProducto = _ctProductos.GetProducto(nCodigoProducto);

            if (RegistroProducto == null) { NotFound(); }
            var nRegistroProductoDTO = _mapper.Map<ProductoDTO>(RegistroProducto);

            return Ok(nRegistroProductoDTO);
        }

        [HttpPost]
        public IActionResult CrearProducto([FromBody] ProductoDTO productoDTO)
        {
            if (productoDTO == null)
            {
                return BadRequest(ModelState);
            }
            var producto = _mapper.Map<ProductosModel>(productoDTO);

            if (!_ctProductos.CreaProducto(producto))
            {
                ModelState.AddModelError("", $"Ocurrio un error al almacenar el producto{producto.CodigoProducto}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetProductoByCodigo", new { nCodigoProducto = productoDTO.CodigoProducto }, producto);
        }
        [HttpPatch("{nCodigoProducto:int}", Name = "GetProductoByCodigo")]
        public IActionResult UpdateProducto(int nCodigoProducto, [FromBody] ProductoDTO productoDTO)
        {
            if (productoDTO == null || nCodigoProducto != productoDTO.CodigoProducto)
            {
                return BadRequest(ModelState);
            }
            var producto = _mapper.Map<ProductosModel>(productoDTO);
            if (!_ctProductos.UpdateProducto(producto))
            {
                ModelState.AddModelError("", $"Ocurrio un error al actualizar el producto{producto.CodigoProducto}");
                    return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
