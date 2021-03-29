using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.DBContexts;
using Model.Models;

namespace VacationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly VacationContext _context;

        public VacationController(VacationContext context)
        {
            _context = context;
        }

        // GET: api/Vacations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacation>>> GetVacations()
        {
            return await _context.Vacations.ToListAsync();
        }

        // GET: api/Vacations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacation>> GetVacation(int id)
        {
            var vacation = await _context.Vacations.FindAsync(id);

            if (vacation == null)
            {
                return NotFound();
            }

            return vacation;
        }

        // PUT: api/Vacations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacation(int id, Vacation vacation)
        {
            if (id != vacation.ID)
            {
                return BadRequest();
            }

            _context.Entry(vacation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationExists(id))
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

        // POST: api/Vacations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vacation>> PostVacation(Vacation vacation)
        {
            _context.Vacations.Add(vacation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacation", new { id = vacation.ID }, vacation);
        }

        // DELETE: api/Vacations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vacation>> DeleteVacation(int id)
        {
            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }

            _context.Vacations.Remove(vacation);
            await _context.SaveChangesAsync();

            return vacation;
        }

        private bool VacationExists(int id)
        {
            return _context.Vacations.Any(e => e.ID == id);
        }
    }
}
