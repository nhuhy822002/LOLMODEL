using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LOLMODEL.Data;
using LOLMODEL.Models;
using Microsoft.AspNetCore.Authorization;


namespace LOLMODEL.Controllers

{
    [Authorize]
    public class LolmodelsController : Controller
    {
        private readonly LOLMODELContext _context;

        public LolmodelsController(LOLMODELContext context)
        {
            _context = context;
        }

        // GET: Lolmodels
        public async Task<IActionResult> Index(string lolmodelGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Lolmodel
                                            orderby b.Genre
                                            select b.Genre;
            var lolmodels = from b in _context.Lolmodel
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                lolmodels = lolmodels.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(lolmodelGenre))
            {
                lolmodels = lolmodels.Where(x => x.Genre == lolmodelGenre);
            }
            var bookGenreVM = new ModelGenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                Models = await lolmodels.ToListAsync()
            };
            return View(bookGenreVM);
        }


        // GET: Lolmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lolmodel = await _context.Lolmodel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lolmodel == null)
            {
                return NotFound();
            }

            return View(lolmodel);
        }

        // GET: Lolmodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lolmodels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price, Rating")] Lolmodel lolmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lolmodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lolmodel);
        }

        // GET: Lolmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lolmodel = await _context.Lolmodel.FindAsync(id);
            if (lolmodel == null)
            {
                return NotFound();
            }
            return View(lolmodel);
        }

        // POST: Lolmodels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price, Rating")] Lolmodel lolmodel)
        {
            if (id != lolmodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lolmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LolmodelExists(lolmodel.Id))
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
            return View(lolmodel);
        }

        // GET: Lolmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lolmodel = await _context.Lolmodel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lolmodel == null)
            {
                return NotFound();
            }

            return View(lolmodel);
        }

        // POST: Lolmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lolmodel = await _context.Lolmodel.FindAsync(id);
            _context.Lolmodel.Remove(lolmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LolmodelExists(int id)
        {
            return _context.Lolmodel.Any(e => e.Id == id);
        }
    }
}
