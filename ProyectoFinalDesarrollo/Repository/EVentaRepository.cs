﻿using ProyectoFinalDesarrollo.Connection;
using ProyectoFinalDesarrollo.Models;
using ProyectoFinalDesarrollo.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Repository
{
    public class EVentaRepository : iEVentaRepository
    {

        private readonly conn _db;

        //creando el constructor
        public EVentaRepository(conn db)
        {
            _db = db;
        }

        public bool ActualizaEVenta(EVentaModel eVenta)
        {
            //throw new NotImplementedException();
            _db.tbl_EVentaModel.Update(eVenta);
            return GuardaEVenta();
        }

        public bool CreaEVenta(EVentaModel eVenta)
        {
            //throw new NotImplementedException();
            _db.tbl_EVentaModel.Add(eVenta);
            return GuardaEVenta();
        }

        public bool BorraEVenta(EVentaModel eVenta)
        {
            //throw new NotImplementedException();
            _db.tbl_EVentaModel.Remove(eVenta);
            return GuardaEVenta();
        }


        public EVentaModel GetEVentaByCodigo(int CodigoVenta)
        {
            //throw new NotImplementedException();
            return _db.tbl_EVentaModel.FirstOrDefault(p => p.CodigoEVenta == CodigoVenta);
        }

        public EVentaModel GetEVentaByCodigoC(int CodigoCliente)
        {
            //throw new NotImplementedException();
            return _db.tbl_EVentaModel.FirstOrDefault(p => p.CodigoCliente == CodigoCliente);
        }

        public EVentaModel GetEVentaByTipo(int CodigoTipo)
        {
            //throw new NotImplementedException();
            return _db.tbl_EVentaModel.FirstOrDefault(p => p.TipoDocumento == CodigoTipo);
        }

        public EVentaModel GetEVentaByEstado(int CodigoEstado)
        {
            //throw new NotImplementedException();
            return _db.tbl_EVentaModel.FirstOrDefault(p => p.Estado == CodigoEstado);
        }

        public ICollection<EVentaModel> GetEVentaModels()
        {
            //throw new NotImplementedException();
            return _db.tbl_EVentaModel.OrderBy(p => p.CodigoEVenta).ToList();
        }


        public bool GuardaEVenta()
        {
            //throw new NotImplementedException();
            return _db.SaveChanges() >= 0 ? true : false;

        }
    }
}
