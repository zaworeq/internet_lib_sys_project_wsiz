using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Internet_Library_System.Data;
using Internet_Library_System.Models;

namespace Internet_Library_System.Controllers
{
    public class BookKeepersController : Controller
    {
        private readonly Internet_Library_SystemContext _context;

        public BookKeepersController(Internet_Library_SystemContext context)
        {
            _context = context;
        }

        // GET: BookKeepers
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookKeepers.ToListAsync());
        }

        // GET: BookKeepers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookKeepers = await _context.BookKeepers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookKeepers == null)
            {
                return NotFound();
            }

            return View(bookKeepers);
        }

        // GET: BookKeepers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookKeepers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname")] BookKeepers bookKeepers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookKeepers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookKeepers);
        }

        // GET: BookKeepers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookKeepers = await _context.BookKeepers.FindAsync(id);
            if (bookKeepers == null)
            {
                return NotFound();
            }
            return View(bookKeepers);
        }

        // POST: BookKeepers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname")] BookKeepers bookKeepers)
        {
            if (id != bookKeepers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookKeepers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookKeepersExists(bookKeepers.Id))
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
            return View(bookKeepers);
        }

        // GET: BookKeepers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookKeepers = await _context.BookKeepers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookKeepers == null)
            {
                return NotFound();
            }

            return View(bookKeepers);
        }

        // POST: BookKeepers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookKeepers = await _context.BookKeepers.FindAsync(id);
            _context.BookKeepers.Remove(bookKeepers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookKeepersExists(int id)
        {
            return _context.BookKeepers.Any(e => e.Id == id);
        }
    }
}
