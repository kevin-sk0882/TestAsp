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
    public class EnseignantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnseignantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enseignant
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Enseignants.Include(e => e.Departement).Include(e => e.Matiere);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Enseignant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignants
                .Include(e => e.Departement)
                .Include(e => e.Matiere)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // GET: Enseignant/Create
        public IActionResult Create()
        {
            ViewData["DepartementId"] = new SelectList(_context.Departements, "Id", "Name");
            ViewData["MatiereId"] = new SelectList(_context.Matieres, "CodeMat", "CodeMat");
            return View();
        }

        // POST: Enseignant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DatePriseFonct,MatiereId,DepartementId,Nom,Prenom,Email,Telephone,Adresse")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enseignant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartementId"] = new SelectList(_context.Departements, "Id", "Name", enseignant.DepartementId);
            ViewData["MatiereId"] = new SelectList(_context.Matieres, "CodeMat", "CodeMat", enseignant.MatiereId);
            return View(enseignant);
        }

        // GET: Enseignant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignants.FindAsync(id);
            if (enseignant == null)
            {
                return NotFound();
            }
            ViewData["DepartementId"] = new SelectList(_context.Departements, "Id", "Name", enseignant.DepartementId);
            ViewData["MatiereId"] = new SelectList(_context.Matieres, "CodeMat", "CodeMat", enseignant.MatiereId);
            return View(enseignant);
        }

        // POST: Enseignant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DatePriseFonct,MatiereId,DepartementId,Nom,Prenom,Email,Telephone,Adresse")] Enseignant enseignant)
        {
            if (id != enseignant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enseignant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseignantExists(enseignant.Id))
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
            ViewData["DepartementId"] = new SelectList(_context.Departements, "Id", "Name", enseignant.DepartementId);
            ViewData["MatiereId"] = new SelectList(_context.Matieres, "CodeMat", "CodeMat", enseignant.MatiereId);
            return View(enseignant);
        }

        // GET: Enseignant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignants
                .Include(e => e.Departement)
                .Include(e => e.Matiere)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // POST: Enseignant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enseignant = await _context.Enseignants.FindAsync(id);
            _context.Enseignants.Remove(enseignant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseignantExists(int id)
        {
            return _context.Enseignants.Any(e => e.Id == id);
        }
    }
}
