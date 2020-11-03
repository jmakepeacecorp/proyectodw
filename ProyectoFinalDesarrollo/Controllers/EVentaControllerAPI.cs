using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.Operations;
using ProyectoFinalDesarrollo.Models;
using ProyectoFinalDesarrollo.Models.DTOs;
using ProyectoFinalDesarrollo.Repository.iRepository;

namespace ProyectoFinalDesarrollo.Controllers
{
    [Route("api/Ventas")]
    [ApiController]
    public class EVentaControllerAPI : Controller //definir solo Controler, no controllerBase
    {
        private readonly iEVentaRepository _ctEVenta;
        private readonly IMapper _mapper;
        public EVentaControllerAPI(iEVentaRepository ctEVenta, IMapper mapper)
        {
            _ctEVenta = ctEVenta;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult ListaEVenta()
        {
            var nListaEVenta = _ctEVenta.GetEVentaModels();
            //Aplicando DTO
            var nListaEVentaDTO = new List<EVentaModelDTO>();
            foreach(var vLista in nListaEVenta)
            {
                nListaEVentaDTO.Add(_mapper.Map<EVentaModelDTO>(vLista));
            }
            //return Ok(nListaEVenta);
            return Ok(nListaEVentaDTO);
        }


        [HttpGet("{nCodigoVenta:int}",Name = "ListaEVentaByCodigo")]
        public IActionResult ListaEVentaByCodigo(int nCodigoVenta)
        {

            var nRegistroEVenta = _ctEVenta.GetEVentaByCodigo(nCodigoVenta);
            if (nRegistroEVenta == null) 
            {
                NotFound();            
            }
            var nRegistroEVentaDTO = _mapper.Map<EVentaModelDTO>(nRegistroEVenta);
            return Ok(nRegistroEVentaDTO);
        }

        [HttpGet("cliente/{nCodigoCliente:int}", Name = "ListaEVentaByCodigoC")]
        public IActionResult ListaEVentaByCodigoC(int nCodigoCliente)
        {

            var nListaEVenta = _ctEVenta.GetEVentaModels();
            //Aplicando DTO
            var nListaEVentaDTO = new List<EVentaModelDTO>();
            foreach (var vLista in nListaEVenta)
            {
                nListaEVentaDTO.Add(_mapper.Map<EVentaModelDTO>(vLista));
            }
            //return Ok(nListaEVenta);
            return Ok(nListaEVentaDTO.Where(m => m.CodigoCliente == nCodigoCliente).ToList());
        }

        [HttpGet("tipo/{nCodigoTipo:int}", Name = "ListaEVentaByTipo")]
        public IActionResult ListaEVentaByTipo(int nCodigoTipo)
        {

            var nListaEVenta = _ctEVenta.GetEVentaModels();
            //Aplicando DTO
            var nListaEVentaDTO = new List<EVentaModelDTO>();
            foreach (var vLista in nListaEVenta)
            {
                nListaEVentaDTO.Add(_mapper.Map<EVentaModelDTO>(vLista));
            }
            //return Ok(nListaEVenta);
            return Ok(nListaEVentaDTO.Where(m => m.TipoDocumento == nCodigoTipo).ToList());
        }

        [HttpGet("estado/{nCodigoEstado:int}", Name = "ListaEVentaByEstado")]
        public IActionResult ListaEVentaByEstado(int nCodigoEstado)
        {

            var nListaEVenta = _ctEVenta.GetEVentaModels();
            //Aplicando DTO
            var nListaEVentaDTO = new List<EVentaModelDTO>();
            foreach (var vLista in nListaEVenta)
            {
                nListaEVentaDTO.Add(_mapper.Map<EVentaModelDTO>(vLista));
            }
            //return Ok(nListaEVenta);
            return Ok(nListaEVentaDTO.Where(m => m.Estado == nCodigoEstado).ToList());
        }


        [HttpPost]
        public IActionResult CrearEVenta([FromBody] EVentaModelSaveDTO ventaDTO) {
           
            if(ventaDTO == null)
            {
                return BadRequest(ModelState);
            }
            
            var eVenta = _mapper.Map<EVentaModel>(ventaDTO);
            
            if (!_ctEVenta.CreaEVenta(eVenta)) //CreaEVenta es un metodo del Repository
            {
                ModelState.AddModelError("", $"Ocurrio un error al guardar el registro {eVenta.CodigoEVenta}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("ListaEVentaByCodigo",new { nCodigoVenta = ventaDTO.CodigoEVenta },eVenta); //se retorna el registro creado
        }

        [HttpPatch("{nCodigoVenta:int}", Name = "ListaEVentaByCodigo")]
        public IActionResult ActualizarEVenta(int nCodigoVenta, [FromBody] EVentaModelDTO ventaDTO)
        {
            if (ventaDTO == null || nCodigoVenta != ventaDTO.CodigoEVenta)
            {
                return BadRequest(ModelState);
            }

            var eVenta = _mapper.Map<EVentaModel>(ventaDTO);

            if (!_ctEVenta.ActualizaEVenta(eVenta))  //ActualizaEVenta es un metodo del Repository
            {
                ModelState.AddModelError("", $"Ocurrio un error al actualizar el codigo { eVenta.CodigoEVenta}");
                return StatusCode(500, ModelState);
            }

            return NoContent(); //no se va retornar ninguna respuesta, solo el codigo del request

        }


        [HttpDelete("{nCodigoVenta:int}", Name = "ListaEVentaByCodigo")]
        public IActionResult borrarEVenta(int nCodigoVenta, [FromBody] EVentaModelDTO ventaDTO)
        {
            if (ventaDTO == null || nCodigoVenta != ventaDTO.CodigoEVenta)
            {
                return BadRequest(ModelState);
            }

            var eVenta = _mapper.Map<EVentaModel>(ventaDTO);

            if (!_ctEVenta.BorraEVenta(eVenta))  //BorraEVenta es un metodo del Repository
            {
                ModelState.AddModelError("", $"Ocurrio un error al borrar el codigo { eVenta.CodigoEVenta}");
                return StatusCode(500, ModelState);
            }

            return NoContent(); //no se va retornar ninguna respuesta, solo el codigo del request

        }

    }
}
