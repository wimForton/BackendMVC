using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackendMVC.Data;
using BackendMVC.Models;

namespace BackendMVC.Controllers
{

    public class MidifileModelsController : Controller
    {
        private readonly BackendMVCContext _context;

        public MidifileModelsController(BackendMVCContext context)
        {
            _context = context;
        }


        //---------------------------------------------views
        // GET: MidifileModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.MidifileModel.ToListAsync());
        }

        // GET: MidifileModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var midifileModel = await _context.MidifileModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (midifileModel == null)
            {
                return NotFound();
            }

            return View(midifileModel);
        }

        // GET: MidifileModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MidifileModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Year,FilePath,Duration")] MidifileModel midifileModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(midifileModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(midifileModel);
        }

        // GET: MidifileModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var midifileModel = await _context.MidifileModel.FindAsync(id);
            if (midifileModel == null)
            {
                return NotFound();
            }
            return View(midifileModel);
        }

        // POST: MidifileModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Year,FilePath,Duration")] MidifileModel midifileModel)
        {
            if (id != midifileModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(midifileModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MidifileModelExists(midifileModel.Id))
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
            return View(midifileModel);
        }

        // GET: MidifileModels/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var midifileModel = await _context.MidifileModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (midifileModel == null)
            {
                return NotFound();
            }

            return View(midifileModel);
        }

        // POST: MidifileModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var midifileModel = await _context.MidifileModel.FindAsync(id);
            if (midifileModel != null)
            {
                _context.MidifileModel.Remove(midifileModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MidifileModelExists(int id)
        {
            return _context.MidifileModel.Any(e => e.Id == id);
        }
    }
}
