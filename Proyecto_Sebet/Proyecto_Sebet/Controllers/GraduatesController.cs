using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Sebet.Models;

namespace Proyecto_Sebet.Controllers
{
    public class GraduatesController : Controller
    {
        private readonly DbSebetPTContext _context;

        public GraduatesController(DbSebetPTContext context)
        {
            _context = context;
        }

        // GET: Graduates
        public async Task<IActionResult> Index()
        {
            var dbSebetPTContext = _context.Graduate.Include(g => g.IdCareerNavigation);
            return View(await dbSebetPTContext.ToListAsync());
        }

        // GET: Graduates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graduate = await _context.Graduate
                .Include(g => g.IdCareerNavigation)
                .FirstOrDefaultAsync(m => m.IdGraduate == id);
            if (graduate == null)
            {
                return NotFound();
            }

            return View(graduate);
        }

        // GET: Graduates/Create
        public IActionResult Create()
        {
            ViewData["IdCareer"] = new SelectList(_context.Career, "IdCareer", "NameCareer");
            return View();
        }

        // POST: Graduates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGraduate,Inscription,GraduateName,LastName,Email,PasswordG,IdCareer")] Graduate graduate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(graduate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCareer"] = new SelectList(_context.Career, "IdCareer", "NameCareer", graduate.IdCareer);
            return View(graduate);
        }

        // GET: Graduates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graduate = await _context.Graduate.FindAsync(id);
            if (graduate == null)
            {
                return NotFound();
            }
            ViewData["IdCareer"] = new SelectList(_context.Career, "IdCareer", "DescriptionCareer", graduate.IdCareer);
            return View(graduate);
        }

        // POST: Graduates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGraduate,Inscription,GraduateName,LastName,Email,PasswordG,IdCareer")] Graduate graduate)
        {
            if (id != graduate.IdGraduate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(graduate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GraduateExists(graduate.IdGraduate))
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
            ViewData["IdCareer"] = new SelectList(_context.Career, "IdCareer", "DescriptionCareer", graduate.IdCareer);
            return View(graduate);
        }

        // GET: Graduates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graduate = await _context.Graduate
                .Include(g => g.IdCareerNavigation)
                .FirstOrDefaultAsync(m => m.IdGraduate == id);
            if (graduate == null)
            {
                return NotFound();
            }

            return View(graduate);
        }

        // POST: Graduates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var graduate = await _context.Graduate.FindAsync(id);
            _context.Graduate.Remove(graduate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GraduateExists(int id)
        {
            return _context.Graduate.Any(e => e.IdGraduate == id);
        }
    }
}
