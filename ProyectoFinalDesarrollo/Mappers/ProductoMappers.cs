using ProyectoFinalDesarrollo.Models;
using ProyectoFinalDesarrollo.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProyectoFinalDesarrollo.Mapper
{
    public class ProductoMappers : Profile

    {

        public ProductoMappers()
        {
            CreateMap<ProductosModel, ProductoAgregar>().ReverseMap();
        }
    }
}