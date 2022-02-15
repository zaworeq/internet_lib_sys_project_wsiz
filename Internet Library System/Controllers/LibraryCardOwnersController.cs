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
    public class LibraryCardOwnersController : Controller
    {
        private readonly Internet_Library_SystemContext _context;

        public LibraryCardOwnersController(Internet_Library_SystemContext context)
        {
            _context = context;
        }

        // GET: LibraryCardOwners
        public async Task<IActionResult> Index()
        {
            return View(await _context.LibraryCardOwners.ToListAsync());
        }

        // GET: LibraryCardOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryCardOwners = await _context.LibraryCardOwners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraryCardOwners == null)
            {
                return NotFound();
            }

            return View(libraryCardOwners);
        }

        // GET: LibraryCardOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibraryCardOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,PESEL")] LibraryCardOwners libraryCardOwners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraryCardOwners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libraryCardOwners);
        }

        // GET: LibraryCardOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryCardOwners = await _context.LibraryCardOwners.FindAsync(id);
            if (libraryCardOwners == null)
            {
                return NotFound();
            }
            return View(libraryCardOwners);
        }

        // POST: LibraryCardOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Email,PESEL")] LibraryCardOwners libraryCardOwners)
        {
            if (id != libraryCardOwners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryCardOwners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryCardOwnersExists(libraryCardOwners.Id))
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
            return View(libraryCardOwners);
        }

        // GET: LibraryCardOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryCardOwners = await _context.LibraryCardOwners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraryCardOwners == null)
            {
                return NotFound();
            }

            return View(libraryCardOwners);
        }

        // POST: LibraryCardOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraryCardOwners = await _context.LibraryCardOwners.FindAsync(id);
            _context.LibraryCardOwners.Remove(libraryCardOwners);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryCardOwnersExists(int id)
        {
            return _context.LibraryCardOwners.Any(e => e.Id == id);
        }
    }
}
