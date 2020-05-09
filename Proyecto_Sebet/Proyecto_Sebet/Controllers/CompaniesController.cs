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
    public class CompaniesController : Controller
    {
        private readonly DbSebetPTContext _context;

        public CompaniesController(DbSebetPTContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var dbSebetPTContext = _context.Company.Include(c => c.IdIndustryNavigation).Include(c => c.IdLegalFormNavigation);
            return View(await dbSebetPTContext.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.IdIndustryNavigation)
                .Include(c => c.IdLegalFormNavigation)
                .FirstOrDefaultAsync(m => m.IdCompany == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["IdIndustry"] = new SelectList(_context.Industry, "IdIndustry", "IndustryName");
            ViewData["IdLegalForm"] = new SelectList(_context.LegalForm, "IdLegalForm", "FormName");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompany,RecluiterName,LastName,Rfc,BusinessName,Email,PasswordR,IdIndustry,IdLegalForm")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdIndustry"] = new SelectList(_context.Industry, "IdIndustry", "IndustryName", company.IdIndustry);
            ViewData["IdLegalForm"] = new SelectList(_context.LegalForm, "IdLegalForm", "FormName", company.IdLegalForm);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["IdIndustry"] = new SelectList(_context.Industry, "IdIndustry", "IndustryName", company.IdIndustry);
            ViewData["IdLegalForm"] = new SelectList(_context.LegalForm, "IdLegalForm", "FormName", company.IdLegalForm);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompany,RecluiterName,LastName,Rfc,BusinessName,Email,PasswordR,IdIndustry,IdLegalForm")] Company company)
        {
            if (id != company.IdCompany)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.IdCompany))
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
            ViewData["IdIndustry"] = new SelectList(_context.Industry, "IdIndustry", "IndustryName", company.IdIndustry);
            ViewData["IdLegalForm"] = new SelectList(_context.LegalForm, "IdLegalForm", "FormName", company.IdLegalForm);
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.IdIndustryNavigation)
                .Include(c => c.IdLegalFormNavigation)
                .FirstOrDefaultAsync(m => m.IdCompany == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.IdCompany == id);
        }
    }
}
