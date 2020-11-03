using ProyectoFinalDesarrollo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Repository.iRepository
{
    public interface iEVentaRepository
    {
        //Definir todos los metodos para recibir la API
        ICollection<EVentaModel>GetEVentaModels(); //devuelve un listado de EVenta
        EVentaModel GetEVentaByCodigo(int CodigoVenta);
        EVentaModel GetEVentaByCodigoC(int CodigoCliente);
        EVentaModel GetEVentaByTipo(int CodigoTipo);
        EVentaModel GetEVentaByEstado(int CodigoEstado);
        bool CreaEVenta(EVentaModel eVenta);
        bool ActualizaEVenta(EVentaModel eVenta);
        bool BorraEVenta(EVentaModel eVenta);
        bool GuardaEVenta();
    }
}
