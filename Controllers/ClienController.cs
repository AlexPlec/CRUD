using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using CRUDModel.Data;

namespace CRUD.Controllers
{
    public class ClientController : Controller
    {
        private readonly CRUDPDBContext _context;

        public ClientController(CRUDPDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _context.ClientModel.ToListAsync();
            foreach (var client in clients)
            {
                client.Orders = await _context.OrderModel
                    .Where(o => o.ClientId == client.Id)
                    .Include(o => o.Product)
                    .ToListAsync();
            }
            return View(clients);
        }

        // GET: CLient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Email,Birthdate,Gender")] ClientModel clientModel
        )
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientModel);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientModel == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel == null)
            {
                return NotFound();
            }
            return View(clientModel);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Name,Email,Birthdate,Gender")] ClientModel clientModel
        )
        {
            if (id != clientModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientModelExists(clientModel.Id))
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
            return View(clientModel);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientModel == null)
            {
                return NotFound();
            }

            var clientModel = await _context.ClientModel.FirstOrDefaultAsync(m => m.Id == id);
            if (clientModel == null)
            {
                return NotFound();
            }

            return View(clientModel);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientModel == null)
            {
                return Problem("Entity set 'CRUDPDBContext.ClientModel'  is null.");
            }
            var clientModel = await _context.ClientModel.FindAsync(id);
            if (clientModel != null)
            {
                _context.ClientModel.Remove(clientModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientModelExists(int id)
        {
            return (_context.ClientModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
