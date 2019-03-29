using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BetEtMechant.Data;
using BetEtMechant.Models;

namespace BetEtMechant.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private readonly BetDbContext _context;

        public ChampionshipsController(BetDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Lister les championnats
        /// </summary>
        /// <returns>une list de Championships</returns>
        // GET: api/Championships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Championship>>> GetToto()
        {
            return await _context.Championships.ToListAsync();
        }

        /// <summary>
        /// Affiche un championnat en fonction de l ID
        /// </summary>
        /// <param name="id">ID recherché</param>
        /// <returns>Un championnat</returns>
        // GET: api/Championships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Championship>> GetChampionship(int id)
        {
            var championship = await _context.Championships.FindAsync(id);

            if (championship == null)
            {
                return NotFound();
            }

            return championship;
        }

        // GET: api/Championships/search/name
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Championship>>> GetToto(SearchModel model)
        {
            return await _context.Championships.Where(x => x.Name.Contains(model.Name)).ToListAsync();
        }

        // PUT: api/Championships/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChampionship(int id, Championship championship)
        {
            if (id != championship.ID)
            {
                return BadRequest();
            }

            _context.Entry(championship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampionshipExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Championships
        [HttpPost]
        public async Task<ActionResult<Championship>> PostChampionship(Championship championship)
        {
            _context.Championships.Add(championship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChampionship", new { id = championship.ID }, championship);
        }

        // DELETE: api/Championships/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Championship>> DeleteChampionship(int id)
        {
            var championship = await _context.Championships.FindAsync(id);
            if (championship == null)
            {
                return NotFound();
            }

            _context.Championships.Remove(championship);
            await _context.SaveChangesAsync();

            return championship;
        }

        private bool ChampionshipExists(int id)
        {
            return _context.Championships.Any(e => e.ID == id);
        }
    }

    public class SearchModel
    {
        public string Name { get; set; }
    }
}
