using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROM.DBContext;
using ROM.Models;

namespace ROM.Controllers
{
    public class ROMTestModelsController : Controller
    {
        private readonly ROMDatabaseContext _context;

        public ROMTestModelsController(ROMDatabaseContext context)
        {
            _context = context;
        }

        // GET: ROMTestModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ROMTestModels.ToListAsync());
        }

        // GET: ROMTestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rOMTestModel = await _context.ROMTestModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rOMTestModel == null)
            {
                return NotFound();
            }

            return View(rOMTestModel);
        }

        // GET: ROMTestModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ROMTestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code,Address")] ROMTestModel rOMTestModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rOMTestModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rOMTestModel);
        }

        // GET: ROMTestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rOMTestModel = await _context.ROMTestModels.FindAsync(id);
            if (rOMTestModel == null)
            {
                return NotFound();
            }
            return View(rOMTestModel);
        }

        // POST: ROMTestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code,Address")] ROMTestModel rOMTestModel)
        {
            if (id != rOMTestModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rOMTestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ROMTestModelExists(rOMTestModel.Id))
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
            return View(rOMTestModel);
        }

        // GET: ROMTestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rOMTestModel = await _context.ROMTestModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rOMTestModel == null)
            {
                return NotFound();
            }

            return View(rOMTestModel);
        }

        // POST: ROMTestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rOMTestModel = await _context.ROMTestModels.FindAsync(id);
            _context.ROMTestModels.Remove(rOMTestModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ROMTestModelExists(int id)
        {
            return _context.ROMTestModels.Any(e => e.Id == id);
        }
    }
}
