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
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_DVentaModel.ToListAsync());
        }

        // GET: DVentaModels/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: DVentaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DVentaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDVenta,CodigoEVenta,CodigoProducto,Cantidad,ValorUnitario,ValorTotal")] DVentaModel dVentaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dVentaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dVentaModel);
        }

        // GET: DVentaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: DVentaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoDVenta,CodigoEVenta,CodigoProducto,Cantidad,ValorUnitario,ValorTotal")] DVentaModel dVentaModel)
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

        // GET: DVentaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: DVentaModels/Delete/5
        [HttpPost, ActionName("Delete")]
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
