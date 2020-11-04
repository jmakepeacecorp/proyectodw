using ProyectoFinalDesarrollo.Models;
using ProyectoFinalDesarrollo.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Mapper
{
    public class ProductoMappers : Profile

    {

        public ProductoMappers()
        {
            CreateMap<ProductosModel, ProductoDTO>().ReverseMap();
        }
    }
}