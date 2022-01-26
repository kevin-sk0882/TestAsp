#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAsp.Data;
using TestAsp.Models;

namespace TestAsp.Controllers
{
    public class MatiereController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MatiereController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Matiere
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Matieres.Include(m => m.Salle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Matiere/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres
                .Include(m => m.Salle)
                .FirstOrDefaultAsync(m => m.CodeMat == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // GET: Matiere/Create
        public IActionResult Create()
        {
            ViewData["SalleId"] = new SelectList(_context.Salles, "Id", "Name");
            return View();
        }

        // POST: Matiere/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodeMat,Name,SalleId")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalleId"] = new SelectList(_context.Salles, "Id", "Name", matiere.SalleId);
            return View(matiere);
        }

        // GET: Matiere/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }
            ViewData["SalleId"] = new SelectList(_context.Salles, "Id", "Name", matiere.SalleId);
            return View(matiere);
        }

        // POST: Matiere/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodeMat,Name,SalleId")] Matiere matiere)
        {
            if (id != matiere.CodeMat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatiereExists(matiere.CodeMat))
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
            ViewData["SalleId"] = new SelectList(_context.Salles, "Id", "Name", matiere.SalleId);
            return View(matiere);
        }

        // GET: Matiere/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matieres
                .Include(m => m.Salle)
                .FirstOrDefaultAsync(m => m.CodeMat == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // POST: Matiere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var matiere = await _context.Matieres.FindAsync(id);
            _context.Matieres.Remove(matiere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatiereExists(string id)
        {
            return _context.Matieres.Any(e => e.CodeMat == id);
        }
    }
}
