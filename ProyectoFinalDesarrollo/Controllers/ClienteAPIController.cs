using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalDesarrollo.Models;
using ProyectoFinalDesarrollo.Models.DTOs;
using ProyectoFinalDesarrollo.Repository.iRepository;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinalDesarrollo.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteAPIController : ControllerBase
    {
        private readonly iClienteRepository _ctCliente;
        private readonly IMapper _mapper;

        public ClienteAPIController(iClienteRepository ctCliente, IMapper mapper)
        {
            _ctCliente = ctCliente;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListaCliente()
        {
            var nListaCliente = _ctCliente.GetClientesModel();
            //Aplicando DTO
            var nListaClienteDTO = new List<ClienteModelDTO>();
            foreach (var vLista in nListaCliente)
            {
                nListaClienteDTO.Add(_mapper.Map<ClienteModelDTO>(vLista));
            }

            return Ok(nListaClienteDTO);
        }


        [HttpGet("{nCodigoCliente:int}", Name = "GetClientesCodigo")]
        public IActionResult GetClientesCodigo(int nCodigoCliente)
        {

            var nRegistroCliente = _ctCliente.GetClientesCodigo(nCodigoCliente);
            if (nRegistroCliente == null)
            {
                NotFound();
            }
            var nRegistroClienteDTO = _mapper.Map<ClienteModelDTO>(nRegistroCliente);
            return Ok(nRegistroClienteDTO);
        }

        [HttpGet("nombre/{nNombreCliente}", Name = "GetClientesNombre")]
        public IActionResult GetClientesNombre(string nNombreCliente)
        {

            var nListaCliente = _ctCliente.GetClientesModel();
            //Aplicando DTO
            var nListaClienteDTO = new List<ClienteModelDTO>();
            foreach (var vLista in nListaCliente)
            {
                nListaClienteDTO.Add(_mapper.Map<ClienteModelDTO>(vLista));
            }
            //return Ok(nListaEVenta);
            return Ok(nListaClienteDTO.Where(m => m.NombreCliente.Equals(nNombreCliente)).ToList());
        }

        [HttpGet("apellido/{nApellidoCliente}", Name = "GetClientesApellido")]
        public IActionResult GetClientesApellido(string nApellidoCliente)
        {

            var nListaCliente = _ctCliente.GetClientesModel();
            //Aplicando DTO
            var nListaClienteDTO = new List<ClienteModelDTO>();
            foreach (var vLista in nListaCliente)
            {
                nListaClienteDTO.Add(_mapper.Map<ClienteModelDTO>(vLista));
            }
            //return Ok(nListaEVenta);
            return Ok(nListaClienteDTO.Where(m => m.ApellidoCliente.Equals(nApellidoCliente)).ToList());
        }

        [HttpGet("nit/{nNit}", Name = "GetClientesNit")]
        public IActionResult GetClientesNit(string nNit)
        {

            var nListaCliente = _ctCliente.GetClientesModel();
            //Aplicando DTO
            var nListaClienteDTO = new List<ClienteModelDTO>();
            foreach (var vLista in nListaCliente)
            {
                nListaClienteDTO.Add(_mapper.Map<ClienteModelDTO>(vLista));
            }
            //return Ok(nListaEVenta);
            return Ok(nListaClienteDTO.Where(m => m.Nit.Equals(nNit)).ToList());
        }


        [HttpPost]
        public IActionResult CrearCliente([FromBody] ClienteModelDTO clienteDTO)
        {

            if (clienteDTO == null)
            {
                return BadRequest(ModelState);
            }

            var Cliente = _mapper.Map<ClientesModel>(clienteDTO);

            if (!_ctCliente.CreaCliente(Cliente)) //CreaEVenta es un metodo del Repository
            {
                ModelState.AddModelError("", $"Ocurrio un error al guardar el registro {Cliente.CodigoCliente}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetClientesCodigo", new { nCodigoCliente = clienteDTO.CodigoCliente }, Cliente); //se retorna el registro creado
        }

        [HttpPatch("{nCodigoCliente:int}", Name = "GetClientesCodigo")]
        public IActionResult ActualizarCliente(int nCodigoCliente, [FromBody] ClienteModelDTO clienteDTO)
        {
            if (clienteDTO == null || nCodigoCliente != clienteDTO.CodigoCliente)
            {
                return BadRequest(ModelState);
            }

            var clientes = _mapper.Map<ClientesModel>(clienteDTO);

            if (!_ctCliente.ActualizarCliente(clientes))  //ActualizaEVenta es un metodo del Repository
            {
                ModelState.AddModelError("", $"Ocurrio un error al actualizar el codigo { clientes.CodigoCliente}");
                return StatusCode(500, ModelState);
            }

            return NoContent(); //no se va retornar ninguna respuesta, solo el codigo del request

        }


        [HttpDelete("{nCodigoCliente:int}", Name = "GetClientesCodigo")]
        public IActionResult BorrarCliente(int nCodigoCliente, [FromBody] ClienteModelDTO clienteDTO)
        {
            if (clienteDTO == null || nCodigoCliente != clienteDTO.CodigoCliente)
            {
                return BadRequest(ModelState);
            }

            var Clientes = _mapper.Map<ClientesModel>(clienteDTO);

            if (!_ctCliente.BorrarCliente(Clientes))  //BorraEVenta es un metodo del Repository
            {
                ModelState.AddModelError("", $"Ocurrio un error al borrar el codigo { Clientes.CodigoCliente}");
                return StatusCode(500, ModelState);
            }

            return NoContent(); //no se va retornar ninguna respuesta, solo el codigo del request

        }

    }
}
