﻿using ProyectoFinalDesarrollo.Models;
using ProyectoFinalDesarrollo.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Repository.iRepository
{
    public interface iClienteRepository
    {
        //Definir todos los metodos para recibir la API
        ICollection<ClientesModel> GetClientesModel(); //devuelve un listado de clientes
        ClientesModel GetClientesCodigo(int CodigoCliente);
        ClientesModel GetClientesNombre(string NombreCliente);
        ClientesModel GetClientesApellido(string ApellidoCliente);
        ClientesModel GetClientesNit(string Nit);
        ClientesModel GetClientesCategoria(int CategoriaCliente);
        bool CreaCliente(ClientesModel clientes);
        bool ActualizarCliente(ClientesModel clientes);
        bool BorrarCliente(ClientesModel clientes);
        bool GuardaCliente();
    }
}
