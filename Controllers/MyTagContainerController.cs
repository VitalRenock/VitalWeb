using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VitalWeb.DAL;
using VitalWeb.Models;

namespace VitalWeb.Controllers
{
    public class MyTagContainerController : Controller
    {
        private readonly VitalDBContext _context;

        public MyTagContainerController(VitalDBContext context)
        {
            _context = context;
        }

        // GET: MyTagContainer
        public async Task<IActionResult> Index()
        {
            List<MyTagContainer> essai = await _context.MyTagContainers.Include(m => m.AllTags).ToListAsync();
            return View(essai);
            // return View(await _context.MyTagContainers.ToListAsync());
        }

        // GET: MyTagContainer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTagContainer = await _context.MyTagContainers
                .FirstOrDefaultAsync(m => m.MyTagContainerID == id);
            if (myTagContainer == null)
            {
                return NotFound();
            }

            return View(myTagContainer);
        }

        // GET: MyTagContainer/Create
        public IActionResult Create()
        {
            ViewData["AllTags"] = new SelectList(_context.Tags, "TagID", "Name");
            return View();
        }

        // POST: MyTagContainer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyTagContainerID,Name")] MyTagContainer myTagContainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myTagContainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myTagContainer);
        }

        // GET: MyTagContainer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTagContainer = await _context.MyTagContainers.FindAsync(id);
            if (myTagContainer == null)
            {
                return NotFound();
            }
            return View(myTagContainer);
        }

        // POST: MyTagContainer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyTagContainerID,Name")] MyTagContainer myTagContainer)
        {
            if (id != myTagContainer.MyTagContainerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myTagContainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyTagContainerExists(myTagContainer.MyTagContainerID))
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
            return View(myTagContainer);
        }

        // GET: MyTagContainer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTagContainer = await _context.MyTagContainers
                .FirstOrDefaultAsync(m => m.MyTagContainerID == id);
            if (myTagContainer == null)
            {
                return NotFound();
            }

            return View(myTagContainer);
        }

        // POST: MyTagContainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myTagContainer = await _context.MyTagContainers.FindAsync(id);
            _context.MyTagContainers.Remove(myTagContainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyTagContainerExists(int id)
        {
            return _context.MyTagContainers.Any(e => e.MyTagContainerID == id);
        }
    }
}
