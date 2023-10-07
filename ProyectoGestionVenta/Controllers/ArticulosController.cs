﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoGestionVenta.Models;

namespace ProyectoGestionVenta.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly GestionVentasContext _context;

        public ArticulosController(GestionVentasContext context)
        {
            _context = context;
        }

        // GET: Articuloes
        public async Task<IActionResult> Index()
        {
            var gestionVentasContext = _context.Articulos.Include(a => a.Categoria).Include(a => a.Proveedor);
            return View(await gestionVentasContext.ToListAsync());
        }

        // GET: Articuloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articulos == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.Categoria)
                .Include(a => a.Proveedor)
                .FirstOrDefaultAsync(m => m.ArticuloId == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articuloes/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre");
            ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "Nombre");
            return View();
        }

        // POST: Articuloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticuloId,CategoriaId,ProveedorId,Codigo,Nombre,PrecioVenta,Costo,Stock,Descripcion,Estado, Categoria, Proveedor")] Articulo articulo)
        {
                articulo.Proveedor = _context.Proveedors.FirstOrDefault(x => x.ProveedorId == articulo.ProveedorId);
                articulo.Categoria = _context.Categoria.FirstOrDefault(x => x.CategoriaId == articulo.CategoriaId);
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            //["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", articulo.CategoriaId);
            //ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "ProveedorId", articulo.ProveedorId);
            //return View(articulo);
        }

        // GET: Articuloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

 
            if (id == null || _context.Articulos == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", articulo.CategoriaId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "ProveedorId", articulo.ProveedorId);
            return View(articulo);
        }

        // POST: Articuloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,Nombre,Descripcion,Estado")] Articulo articulo)
        {
            articulo.Proveedor = _context.Proveedors.FirstOrDefault(x => x.ProveedorId == articulo.ProveedorId);
            articulo.Categoria = _context.Categoria.FirstOrDefault(x => x.CategoriaId == articulo.CategoriaId);
            if (id != articulo.ArticuloId)
            {
                return NotFound();
            }

 
            try
            {
                articulo.Proveedor = _context.Proveedors.FirstOrDefault(x => x.ProveedorId == articulo.ProveedorId);
                articulo.Categoria = _context.Categoria.FirstOrDefault(x => x.CategoriaId == articulo.CategoriaId);

                _context.Update(articulo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(articulo.ArticuloId))
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

        // GET: Articuloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articulos == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.Categoria)
                .Include(a => a.Proveedor)
                .FirstOrDefaultAsync(m => m.ArticuloId == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articulos == null)
            {
                return Problem("Entity set 'GestionVentasContext.Articulos'  is null.");
            }
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
          return (_context.Articulos?.Any(e => e.ArticuloId == id)).GetValueOrDefault();
        }
    }
}
