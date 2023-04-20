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
    public class RecipientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipients.ToListAsync());
        }

        // GET: Recipients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipients = await _context.Recipients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipients == null)
            {
                return NotFound();
            }

            return View(recipients);
        }

        // GET: Recipients/Create
        public async Task<IActionResult> Create()
        {
            var s = _context.Storage.ToList();
            ViewBag.NameProduct = new SelectList(s, "Id", "Name");

            return View();
        }

        // POST: Recipients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipients recipients)
        {
            ViewBag.NameProduct = new SelectList(_context.Storage.Select(s => new { s.Id, s.Name }), "Name", "Name");

            if (ModelState.IsValid)
            {
                var storage = await _context.Storage.FirstOrDefaultAsync(s => s.Name == recipients.NameProduct);
                if (storage == null)
                {
                    ModelState.AddModelError(string.Empty, "Товар не найден");
                    return View(recipients);
                }

                if (storage.Quantity < recipients.Quantity)
                {
                    ModelState.AddModelError(string.Empty, "Количество товара недостаточно");
                    return View(recipients);
                }

                storage.Quantity -= recipients.Quantity;

                _context.Update(storage); // обновление количества товара в хранилище
                recipients.StorageId = storage.Id; // назначение StorageId
                await _context.Recipients.AddAsync(recipients);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(recipients);
        }


        // GET: Recipients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipients = await _context.Recipients.FindAsync(id);
            if (recipients == null)
            {
                return NotFound();
            }
            return View(recipients);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameProduct,Fakultet,Kafedra,Recipienter,Quantity,Desk,Data")] Recipients recipients)
        {
            if (id != recipients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipientsExists(recipients.Id))
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
            return View(recipients);
        }

        // GET: Recipients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipients = await _context.Recipients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipients == null)
            {
                return NotFound();
            }

            return View(recipients);
        }

        // POST: Recipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipients = await _context.Recipients.FindAsync(id);
            _context.Recipients.Remove(recipients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipientsExists(int id)
        {
            return _context.Recipients.Any(e => e.Id == id);
        }
    }
}
