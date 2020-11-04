using ProyectoFinalDesarrollo.Connection;
using ProyectoFinalDesarrollo.Models;
using ProyectoFinalDesarrollo.Models.DTOs;
using ProyectoFinalDesarrollo.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Repository
{
    public class ClienteRepository : iClienteRepository
    {
        private readonly conn _db;

        //creando el constructor
        public ClienteRepository(conn db)
        {
            _db = db;
        }
        public bool ActualizarCliente(ClientesModel clientes)
        {
            //throw new NotImplementedException();
            _db.tbl_ClientesModel.Update(clientes);
            return GuardaCliente();
        }
        public bool BorrarCliente(ClientesModel clientes)
        {
            //throw new NotImplementedException();
            _db.tbl_ClientesModel.Remove(clientes);
            return GuardaCliente();
        }

        public bool CreaCliente(ClientesModel clientes)
        {
            //throw new NotImplementedException();
            _db.tbl_ClientesModel.Add(clientes);
            return GuardaCliente();
        }

        public ClientesModel GetClientesApellido(string ApellidoCliente)
        {
            //throw new NotImplementedException();
            return _db.tbl_ClientesModel.FirstOrDefault(p => p.ApellidoCliente == ApellidoCliente);
        }

        public ClientesModel GetClientesCategoria(int CategoriaCliente)
        {
            //throw new NotImplementedException();
            return _db.tbl_ClientesModel.FirstOrDefault(p => p.CategoriaCliente == CategoriaCliente);
        }

        public ClientesModel GetClientesCodigo(int CodigoCliente)
        {
            //throw new NotImplementedException();
            return _db.tbl_ClientesModel.FirstOrDefault(p => p.CodigoCliente == CodigoCliente);
        }

        public ICollection<ClientesModel> GetClientesModel()
        {
            //throw new NotImplementedException();
            return _db.tbl_ClientesModel.OrderBy(p => p.CodigoCliente).ToList();
        }

        public ClientesModel GetClientesNit(string Nit)
        {
            //throw new NotImplementedException();
            return _db.tbl_ClientesModel.FirstOrDefault(p => p.Nit == Nit);
        }

        public ClientesModel GetClientesNombre(string NombreCliente)
        {
            //throw new NotImplementedException();
            return _db.tbl_ClientesModel.FirstOrDefault(p => p.NombreCliente == NombreCliente);
        }

        public bool GuardaCliente()
        {
            //throw new NotImplementedException();
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
