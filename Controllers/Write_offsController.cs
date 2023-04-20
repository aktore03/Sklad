using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sklad.Data;
using Sklad.Models;

namespace Sklad.Controllers
{
    public class Write_offsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Write_offsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Write_offs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Write_offs.ToListAsync());
        }

        // GET: Write_offs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var write_offs = await _context.Write_offs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (write_offs == null)
            {
                return NotFound();
            }

            return View(write_offs);
        }

        // GET: Write_offs/Create
        public IActionResult Create()
        {

            ViewBag.NameProduct = new SelectList(_context.Recipients.Select(s => new { s.Id, s.NameProduct }), "NameProduct", "NameProduct");
            return View();
        }

        // POST: Write_offs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Write_offs write_offs)
        {

            ViewBag.NameProduct = new SelectList(_context.Recipients.Select(s => new { s.Id, s.NameProduct }), "NameProduct", "NameProduct");
            if (ModelState.IsValid)
            {
                var storage = await _context.Recipients.FirstOrDefaultAsync(s => s.NameProduct == write_offs.NameProduct && s.Id == write_offs.ProductId);
            if (storage == null)
            {
                ModelState.AddModelError(string.Empty, "Товар не найден");
                return View(write_offs);
            }

            if (storage.Quantity < write_offs.Quantity)
            {
                ModelState.AddModelError(string.Empty, "Количество товара недостаточно");
                return View(write_offs);
            }

            storage.Quantity -= write_offs.Quantity;

            _context.Update(storage); // обновление количества товара в хранилище
            await _context.Write_offs.AddAsync(write_offs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

            return View(write_offs);
        }

        // GET: Write_offs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var write_offs = await _context.Write_offs.FindAsync(id);
            if (write_offs == null)
            {
                return NotFound();
            }
            return View(write_offs);
        }

        // POST: Write_offs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameProduct,Fakultet,Kafedra,Writer,Quantity,Desk,Data")] Write_offs write_offs)
        {
            if (id != write_offs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(write_offs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Write_offsExists(write_offs.Id))
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
            return View(write_offs);
        }

        // GET: Write_offs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var write_offs = await _context.Write_offs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (write_offs == null)
            {
                return NotFound();
            }

            return View(write_offs);
        }

        // POST: Write_offs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var write_offs = await _context.Write_offs.FindAsync(id);
            _context.Write_offs.Remove(write_offs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Write_offsExists(int id)
        {
            return _context.Write_offs.Any(e => e.Id == id);
        }
    }
}
