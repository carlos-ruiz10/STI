using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STI.Models;

namespace STI.Controllers
{
    public class temas_cursoController : Controller
    {
        private readonly STIContext _context;

        public temas_cursoController(STIContext context)
        {
            _context = context;
        }

        // GET: temas_curso
        public async Task<IActionResult> Index()
        {
            var sTIContext = _context.temas_curso.Include(t => t.curso);
            return View(await sTIContext.ToListAsync());
        }

        // GET: temas_curso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temas_curso = await _context.temas_curso
                .Include(t => t.curso)
                .SingleOrDefaultAsync(m => m.id_temas == id);
            if (temas_curso == null)
            {
                return NotFound();
            }

            return View(temas_curso);
        }

        // GET: temas_curso/Create
        public IActionResult Create()
        {
            ViewData["id_curso"] = new SelectList(_context.curso, "id_curso", "nivel");
            return View();
        }

        // POST: temas_curso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_temas,nombre_tema,id_curso")] temas_curso temas_curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temas_curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_curso"] = new SelectList(_context.curso, "id_curso", "nivel", temas_curso.id_curso);
            return View(temas_curso);
        }

        // GET: temas_curso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temas_curso = await _context.temas_curso.SingleOrDefaultAsync(m => m.id_temas == id);
            if (temas_curso == null)
            {
                return NotFound();
            }
            ViewData["id_curso"] = new SelectList(_context.curso, "id_curso", "nivel", temas_curso.id_curso);
            return View(temas_curso);
        }

        // POST: temas_curso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_temas,nombre_tema,id_curso")] temas_curso temas_curso)
        {
            if (id != temas_curso.id_temas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temas_curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!temas_cursoExists(temas_curso.id_temas))
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
            ViewData["id_curso"] = new SelectList(_context.curso, "id_curso", "nivel", temas_curso.id_curso);
            return View(temas_curso);
        }

        // GET: temas_curso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temas_curso = await _context.temas_curso
                .Include(t => t.curso)
                .SingleOrDefaultAsync(m => m.id_temas == id);
            if (temas_curso == null)
            {
                return NotFound();
            }

            return View(temas_curso);
        }

        // POST: temas_curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temas_curso = await _context.temas_curso.SingleOrDefaultAsync(m => m.id_temas == id);
            _context.temas_curso.Remove(temas_curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool temas_cursoExists(int id)
        {
            return _context.temas_curso.Any(e => e.id_temas == id);
        }
    }
}
