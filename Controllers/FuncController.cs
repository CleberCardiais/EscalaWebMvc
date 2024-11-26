using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EscalaWebMvc.Data;
using EscalaWebMvc.Models;

namespace EscalaWebMvc.Controllers
{
    public class FuncController : Controller
    {
        private readonly EscalaWebMvcContext _context;

        public FuncController(EscalaWebMvcContext context)
        {
            _context = context;
        }

        // GET: Func
        public async Task<IActionResult> Index()
        {
            return View(await _context.Func.ToListAsync());
        }

        // GET: Func/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var func = await _context.Func
                .FirstOrDefaultAsync(m => m.Id == id);
            if (func == null)
            {
                return NotFound();
            }

            return View(func);
        }

        // GET: Func/Create
        public IActionResult Create()
        {
            ViewBag.Areas = new SelectList(_context.Area, "Id", "Zona");
            return View();
        }

        // POST: Func/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SetorId")] Func func)
        {
            if (ModelState.IsValid)
            {
                _context.Add(func);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recarregar a lista de áreas em caso de erro
            ViewBag.Areas = new SelectList(_context.Area, "Id", "Zona");
            return View(func);
        }

        // GET: Func/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var func = await _context.Func.FindAsync(id);
            if (func == null)
            {
                return NotFound();
            }
            return View(func);
        }

        // POST: Func/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Func func)
        {
            if (id != func.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(func);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncExists(func.Id))
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
            return View(func);
        }

        // GET: Func/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var func = await _context.Func
                .FirstOrDefaultAsync(m => m.Id == id);
            if (func == null)
            {
                return NotFound();
            }

            return View(func);
        }

        // POST: Func/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var func = await _context.Func.FindAsync(id);
            if (func != null)
            {
                _context.Func.Remove(func);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncExists(int id)
        {
            return _context.Func.Any(e => e.Id == id);
        }
    }
}
