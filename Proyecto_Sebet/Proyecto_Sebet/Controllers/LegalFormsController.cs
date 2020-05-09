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
    public class LegalFormsController : Controller
    {
        private readonly DbSebetPTContext _context;

        public LegalFormsController(DbSebetPTContext context)
        {
            _context = context;
        }

        // GET: LegalForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.LegalForm.ToListAsync());
        }

        // GET: LegalForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legalForm = await _context.LegalForm
                .FirstOrDefaultAsync(m => m.IdLegalForm == id);
            if (legalForm == null)
            {
                return NotFound();
            }

            return View(legalForm);
        }

        // GET: LegalForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LegalForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLegalForm,FormName,DescripionL")] LegalForm legalForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legalForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(legalForm);
        }

        // GET: LegalForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legalForm = await _context.LegalForm.FindAsync(id);
            if (legalForm == null)
            {
                return NotFound();
            }
            return View(legalForm);
        }

        // POST: LegalForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLegalForm,FormName,DescripionL")] LegalForm legalForm)
        {
            if (id != legalForm.IdLegalForm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legalForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegalFormExists(legalForm.IdLegalForm))
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
            return View(legalForm);
        }

        // GET: LegalForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legalForm = await _context.LegalForm
                .FirstOrDefaultAsync(m => m.IdLegalForm == id);
            if (legalForm == null)
            {
                return NotFound();
            }

            return View(legalForm);
        }

        // POST: LegalForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var legalForm = await _context.LegalForm.FindAsync(id);
            _context.LegalForm.Remove(legalForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegalFormExists(int id)
        {
            return _context.LegalForm.Any(e => e.IdLegalForm == id);
        }
    }
}
