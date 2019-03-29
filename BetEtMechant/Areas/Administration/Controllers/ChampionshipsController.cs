using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BetEtMechant.Data;
using BetEtMechant.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace BetEtMechant.Areas.Administration.Controllers
{
   
    public class ChampionshipsController : BaseAdminController
    {
        public ChampionshipsController(BetDbContext context) : base(context)
        {
        }

        // GET: Administration/Championships
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Nouveau championnat";
            return View(await _context.Championships.ToListAsync());
        }

        // GET: Administration/Championships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championship = await _context.Championships
                .FirstOrDefaultAsync(m => m.ID == id);
            if (championship == null)
            {
                return NotFound();
            }

            return View(championship);
        }

        // GET: Administration/Championships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/Championships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ID")] Championship championship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(championship);
                await _context.SaveChangesAsync();
                DisplayMessage("Championnat créé", Class.TypeMessage.SUCCESS);
                return RedirectToAction(nameof(Index));
            }
            return View(championship);
        }

        // GET: Administration/Championships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championship = await _context.Championships.FindAsync(id);
            if (championship == null)
            {
                return NotFound();
            }
            return View(championship);
        }

        // POST: Administration/Championships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ID")] Championship championship)
        {
            if (id != championship.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(championship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampionshipExists(championship.ID))
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
            return View(championship);
        }

        [HttpPost]
        // GET: Administration/Championships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championship = await _context.Championships
                .FirstOrDefaultAsync(m => m.ID == id);
            if (championship == null)
            {
                return NotFound();
            }

            _context.Championships.Remove(championship);
            try
            {
                await _context.SaveChangesAsync();
            }catch(Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message="Ce championnat possède des équipes, Vous ne pouvez pas le supprimer." });
            }
            return Json(championship);
        }

        /*// POST: Administration/Championships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var championship = await _context.Championships.FindAsync(id);
            _context.Championships.Remove(championship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool ChampionshipExists(int id)
        {
            return _context.Championships.Any(e => e.ID == id);
        }
    }
}
