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
    public class IndustriesController : Controller
    {
        private readonly DbSebetPTContext _context;

        public IndustriesController(DbSebetPTContext context)
        {
            _context = context;
        }

        // GET: Industries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Industry.ToListAsync());
        }

        // GET: Industries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industry = await _context.Industry
                .FirstOrDefaultAsync(m => m.IdIndustry == id);
            if (industry == null)
            {
                return NotFound();
            }

            return View(industry);
        }

        // GET: Industries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Industries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIndustry,IndustryName,DescriptionI")] Industry industry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(industry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(industry);
        }

        // GET: Industries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industry = await _context.Industry.FindAsync(id);
            if (industry == null)
            {
                return NotFound();
            }
            return View(industry);
        }

        // POST: Industries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIndustry,IndustryName,DescriptionI")] Industry industry)
        {
            if (id != industry.IdIndustry)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(industry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndustryExists(industry.IdIndustry))
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
            return View(industry);
        }

        // GET: Industries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var industry = await _context.Industry
                .FirstOrDefaultAsync(m => m.IdIndustry == id);
            if (industry == null)
            {
                return NotFound();
            }

            return View(industry);
        }

        // POST: Industries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var industry = await _context.Industry.FindAsync(id);
            _context.Industry.Remove(industry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndustryExists(int id)
        {
            return _context.Industry.Any(e => e.IdIndustry == id);
        }
    }
}
