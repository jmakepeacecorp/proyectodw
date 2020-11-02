using Microsoft.EntityFrameworkCore;
using ProyectoFinalDesarrollo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalDesarrollo.Connection
{
    public class conn:DbContext
    {
        public conn(DbContextOptions<conn> options) : base(options)
        {

        }

        public DbSet<ClientesModel> tbl_ClientesModel { get; set; }

        public DbSet<ProductosModel> tbl_ProductosModel { get; set; }

        public DbSet<EVentaModel> tbl_EVentaModel { get; set; }

        public DbSet<DVentaModel> tbl_DVentaModel { get; set; }

        

    }
}
