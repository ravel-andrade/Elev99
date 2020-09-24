using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Elev99.Data;
using Elev99.Models;
using Elev99.Services;

namespace Elev99.Controllers
{
    public class CollectedDatasController : Controller
    {
        private readonly CollectedDataService _collectedDataService;
        private readonly Elev99Context _context;

        public CollectedDatasController(Elev99Context context)
        {
            _context = context;
        }

        // GET: CollectedDatas
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            
            return View(await PaginatedList<CollectedData>.CreateAsync(_context.CollectedData, pageNumber, 8));
        }

        // GET: CollectedDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectedData = await _context.CollectedData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectedData == null)
            {
                return NotFound();
            }

            return View(collectedData);
        }

        // GET: CollectedDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CollectedDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Floor,Elevator,Shift")] CollectedData collectedData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collectedData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collectedData);
        }

        // GET: CollectedDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectedData = await _context.CollectedData.FindAsync(id);
            if (collectedData == null)
            {
                return NotFound();
            }
            return View(collectedData);
        }

        // POST: CollectedDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Floor,Elevator,Shift")] CollectedData collectedData)
        {
            if (id != collectedData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collectedData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectedDataExists(collectedData.Id))
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
            return View(collectedData);
        }

        // GET: CollectedDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectedData = await _context.CollectedData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectedData == null)
            {
                return NotFound();
            }

            return View(collectedData);
        }

        // POST: CollectedDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collectedData = await _context.CollectedData.FindAsync(id);
            _context.CollectedData.Remove(collectedData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectedDataExists(int id)
        {
            return _context.CollectedData.Any(e => e.Id == id);
        }

        
    }
}
