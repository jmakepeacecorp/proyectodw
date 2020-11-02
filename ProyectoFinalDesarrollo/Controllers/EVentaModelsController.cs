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
    public class EVentaModelsController : Controller
    {
        private readonly conn _context;

        public EVentaModelsController(conn context)
        {
            _context = context;
        }

        // GET: EVentaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_EVentaModel.ToListAsync());
        }

        // GET: EVentaModels/Details/5
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eVentaModel = await _context.tbl_EVentaModel
                .FirstOrDefaultAsync(m => m.CodigoEVenta == id);
            if (eVentaModel == null)
            {
                return NotFound();
            }

            return View(eVentaModel);
        }

        // GET: EVentaModels/Create
        public IActionResult Agregar()
        {
            var list = _context.tbl_ClientesModel.ToList();
            ViewBag.CodigoCliente = new SelectList(list, "CodigoCliente", "NombreCliente");
            return View();
        }

        // GET: EVentaModels/Create
        public IActionResult AgregarNC()
        {
            var list = _context.tbl_ClientesModel.ToList();
            ViewBag.CodigoCliente = new SelectList(list, "CodigoCliente", "NombreCliente");
            return View();
        }

        // GET: EVentaModels/Create
        public IActionResult AgregarDEV()
        {
            var list = _context.tbl_ClientesModel.ToList();
            ViewBag.CodigoCliente = new SelectList(list, "CodigoCliente", "NombreCliente");
            return View();
        }

        // POST: EVentaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar([Bind("CodigoEVenta,Fecha,CodigoCliente,TipoDocumento,Estado")] EVentaModel eVentaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eVentaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eVentaModel);
        }

        // GET: EVentaModels/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eVentaModel = await _context.tbl_EVentaModel.FindAsync(id);
            if (eVentaModel == null)
            {
                return NotFound();
            }
            return View(eVentaModel);
        }

        // POST: EVentaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("CodigoEVenta,Fecha,CodigoCliente,TipoDocumento,Estado")] EVentaModel eVentaModel)
        {
            if (id != eVentaModel.CodigoEVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eVentaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EVentaModelExists(eVentaModel.CodigoEVenta))
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
            return View(eVentaModel);
        }

        // GET: EVentaModels/Delete/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eVentaModel = await _context.tbl_EVentaModel
                .FirstOrDefaultAsync(m => m.CodigoEVenta == id);
            if (eVentaModel == null)
            {
                return NotFound();
            }

            return View(eVentaModel);
        }

        // GET: EVentaModels/Delete/5
        public async Task<IActionResult> Anular(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eVentaModel = await _context.tbl_EVentaModel
                .FirstOrDefaultAsync(m => m.CodigoEVenta == id);
            if (eVentaModel == null)
            {
                return NotFound();
            }

            return View(eVentaModel);
        }

        // POST: EVentaModels/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eVentaModel = await _context.tbl_EVentaModel.FindAsync(id);
            _context.tbl_EVentaModel.Remove(eVentaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: EVentaModels/Delete/5
        [HttpPost, ActionName("Anular")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AnularConfirmed(int id)
        {
            var eVentaModel = await _context.tbl_EVentaModel.FindAsync(id);
            _context.tbl_EVentaModel.Update(eVentaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EVentaModelExists(int id)
        {
            return _context.tbl_EVentaModel.Any(e => e.CodigoEVenta == id);
        }
    }
}
