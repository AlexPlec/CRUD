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
    public class OrderController : Controller
    {
        private readonly CRUDPDBContext _context;

        public OrderController(CRUDPDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.OrderModel
                .Include(o => o.Client)
                .Include(o => o.Product)
                .ToListAsync();

            foreach (var order in orders)
            {
                order.Client.Name = order.Client?.Name;
                order.Product.Title = order.Product?.Title;
            }
            return View(orders);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewBag.Products = _context.ProductModel.ToList();
            ViewBag.Clients = _context.ClientModel.ToList();
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,ClientId,ProductId,Quantity,Status")] OrderModel orderModel
        )
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Products = _context.ProductModel.ToList();
            ViewBag.Clients = _context.ClientModel.ToList();
            return View(orderModel);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderModel == null)
            {
                return NotFound();
            }

            var orderModel = await _context.OrderModel.FindAsync(id);

            if (orderModel == null)
            {
                return NotFound();
            }

            ViewBag.Products = _context.ProductModel.ToList();
            ViewBag.Clients = _context.ClientModel.ToList();
            return View(orderModel);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,ClientId,ProductId,Quantity,Status")] OrderModel orderModel
        )
        {
            if (id != orderModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderModelExists(orderModel.Id))
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
            return View(orderModel);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderModel == null)
            {
                return NotFound();
            }

            var orderModel = await _context.OrderModel.FirstOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderModel == null)
            {
                return Problem("Entity set 'CRUDPDBContext.OrderModel'  is null.");
            }
            var orderModel = await _context.OrderModel.FindAsync(id);
            if (orderModel != null)
            {
                _context.OrderModel.Remove(orderModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderModelExists(int id)
        {
            return (_context.OrderModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
