using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalDesarrollo.Connection;
using ProyectoFinalDesarrollo.Models;

namespace ProyectoFinalDesarrollo.Controllers
{
    public class DVentaModelsController : Controller
    {
        private readonly conn _context;

        public DVentaModelsController(conn context)
        {
            _context = context;
        }

        // GET: DVentaModels
        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.tbl_DVentaModel.Where(m => m.CodigoEVenta == id).ToListAsync());
        }

        // GET: DVentaModels/Detallesp/5
        public async Task<IActionResult> Detallesp(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVentaModel = await _context.tbl_DVentaModel
                .FirstOrDefaultAsync(m => m.CodigoDVenta == id);
            if (dVentaModel == null)
            {
                return NotFound();
            }

            return View(dVentaModel);
        }

        // GET: DVentaModels/Agregarp
        public IActionResult Agregarp()
        {
            //return View();
            var list = _context.tbl_ProductosModel.ToList();
            ViewBag.CodigoProducto = new SelectList(list, "CodigoProducto", "Descripcion");
            return View();
        }


        [Route("/Index/{id?}")]
        public IActionResult ToAction(int id)
        {
            return View("Index", id);
        }

        // POST: DVentaModels/Agregarp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregarp([Bind("CodigoDVenta,CodigoEVenta,CodigoProducto,Cantidad,ValorUnitario,ValorTotal")] DVentaModel dVentaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dVentaModel);
                await _context.SaveChangesAsync();
                //ControllerContext.RouteData.Values.Add("id", dVentaModel.CodigoEVenta);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction(nameof(Index),new { Id= dVentaModel.CodigoEVenta});
            }
            return View(dVentaModel);
        }

        // GET: DVentaModels/Editarp/5
        public async Task<IActionResult> Editarp(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVentaModel = await _context.tbl_DVentaModel.FindAsync(id);
            if (dVentaModel == null)
            {
                return NotFound();
            }
            return View(dVentaModel);
        }

        // POST: DVentaModels/Editarp/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editarp(int id, [Bind("CodigoDVenta,CodigoEVenta,CodigoProducto,Cantidad,ValorUnitario,ValorTotal")] DVentaModel dVentaModel)
        {
            if (id != dVentaModel.CodigoDVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dVentaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVentaModelExists(dVentaModel.CodigoDVenta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dVentaModel);
        }

        // GET: DVentaModels/Eliminarp/5
        public async Task<IActionResult> Eliminarp(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dVentaModel = await _context.tbl_DVentaModel
                .FirstOrDefaultAsync(m => m.CodigoDVenta == id);
            if (dVentaModel == null)
            {
                return NotFound();
            }

            return View(dVentaModel);
        }

        // POST: DVentaModels/Eliminarp/5
        [HttpPost, ActionName("Eliminarp")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dVentaModel = await _context.tbl_DVentaModel.FindAsync(id);
            _context.tbl_DVentaModel.Remove(dVentaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DVentaModelExists(int id)
        {
            return _context.tbl_DVentaModel.Any(e => e.CodigoDVenta == id);
        }
    }
}
