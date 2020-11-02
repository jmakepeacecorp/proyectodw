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
    public class ClientesModelsController : Controller
    {
        private readonly conn _context;

        public ClientesModelsController(conn context)
        {
            _context = context;
        }

        // GET: ClientesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbl_ClientesModel.ToListAsync());
        }

        // GET: ClientesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.tbl_ClientesModel
                .FirstOrDefaultAsync(m => m.CodigoCliente == id);
            if (clientesModel == null)
            {
                return NotFound();
            }

            return View(clientesModel);
        }

        // GET: ClientesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCliente,NombreCliente,ApellidoCliente,Nit,Direccion,CategoriaCliente")] ClientesModel clientesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientesModel);
        }

        // GET: ClientesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.tbl_ClientesModel.FindAsync(id);
            if (clientesModel == null)
            {
                return NotFound();
            }
            return View(clientesModel);
        }

        // POST: ClientesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCliente,NombreCliente,ApellidoCliente,Nit,Direccion,CategoriaCliente")] ClientesModel clientesModel)
        {
            if (id != clientesModel.CodigoCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesModelExists(clientesModel.CodigoCliente))
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
            return View(clientesModel);
        }

        // GET: ClientesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesModel = await _context.tbl_ClientesModel
                .FirstOrDefaultAsync(m => m.CodigoCliente == id);
            if (clientesModel == null)
            {
                return NotFound();
            }

            return View(clientesModel);
        }

        // POST: ClientesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientesModel = await _context.tbl_ClientesModel.FindAsync(id);
            _context.tbl_ClientesModel.Remove(clientesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesModelExists(int id)
        {
            return _context.tbl_ClientesModel.Any(e => e.CodigoCliente == id);
        }
    }
}
