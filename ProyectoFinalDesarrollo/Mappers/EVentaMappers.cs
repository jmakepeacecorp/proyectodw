using AutoMapper;
using ProyectoFinalDesarrollo.Models;
using ProyectoFinalDesarrollo.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Mappers
{
    public class EVentaMappers:Profile
    {
        public EVentaMappers()
        {
            //hacer una relacion entre DTO y modelos iniciales
            CreateMap<EVentaModel, EVentaModelDTO>().ReverseMap();
            CreateMap<EVentaModel, EVentaModelSaveDTO>().ReverseMap();
        }
    }
}
