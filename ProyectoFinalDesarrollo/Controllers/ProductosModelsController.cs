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
    public class ProductosModelsController : Controller
    {
        private readonly conn _context;

        public ProductosModelsController(conn context)
        {
            _context = context;
        }

        // GET: ProductosModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_ProductosModel.ToListAsync());
        }

        // GET: ProductosModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosModel = await _context.tbl_ProductosModel
                .FirstOrDefaultAsync(m => m.CodigoProducto == id);
            if (productosModel == null)
            {
                return NotFound();
            }

            return View(productosModel);
        }

        // GET: ProductosModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductosModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoProducto,Descripcion,CodigoProveedor,Fecha,UbicacionFisica,ExistenciaMinima,TipoProducto")] ProductosModel productosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productosModel);
        }

        // GET: ProductosModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosModel = await _context.tbl_ProductosModel.FindAsync(id);
            if (productosModel == null)
            {
                return NotFound();
            }
            return View(productosModel);
        }

        // POST: ProductosModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoProducto,Descripcion,CodigoProveedor,Fecha,UbicacionFisica,ExistenciaMinima,TipoProducto")] ProductosModel productosModel)
        {
            if (id != productosModel.CodigoProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosModelExists(productosModel.CodigoProducto))
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
            return View(productosModel);
        }

        // GET: ProductosModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosModel = await _context.tbl_ProductosModel
                .FirstOrDefaultAsync(m => m.CodigoProducto == id);
            if (productosModel == null)
            {
                return NotFound();
            }

            return View(productosModel);
        }

        // POST: ProductosModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productosModel = await _context.tbl_ProductosModel.FindAsync(id);
            _context.tbl_ProductosModel.Remove(productosModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosModelExists(int id)
        {
            return _context.tbl_ProductosModel.Any(e => e.CodigoProducto == id);
        }
    }
}
