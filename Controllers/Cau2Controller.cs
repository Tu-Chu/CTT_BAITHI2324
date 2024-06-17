using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CHUTHIENTU_639.Models;
using Cau2;

namespace CHUTHIENTU_639.Controllers
{
    public class Cau2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Cau2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cau2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cau2.ToListAsync());
        }

        // GET: Cau2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cau2 = await _context.Cau2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cau2 == null)
            {
                return NotFound();
            }

            return View(cau2);
        }

        // GET: Cau2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cau2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address")] Cau2 cau2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cau2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cau2);
        }

        // GET: Cau2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cau2 = await _context.Cau2.FindAsync(id);
            if (cau2 == null)
            {
                return NotFound();
            }
            return View(cau2);
        }

        // POST: Cau2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address")] Cau2 cau2)
        {
            if (id != cau2.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cau2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cau2Exists(cau2.ID))
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
            return View(cau2);
        }

        // GET: Cau2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cau2 = await _context.Cau2
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cau2 == null)
            {
                return NotFound();
            }

            return View(cau2);
        }

        // POST: Cau2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cau2 = await _context.Cau2.FindAsync(id);
            if (cau2 != null)
            {
                _context.Cau2.Remove(cau2);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cau2Exists(int id)
        {
            return _context.Cau2.Any(e => e.ID == id);
        }
    }
}
