using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.DBContexts;
using Model.Models;
using Service.Serv;
using Service.Services;

namespace VacationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService _vacationService;

        public VacationController(IVacationService vacationService)
        {
            this._vacationService = vacationService;
        }

        // GET: api/Vacations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacation>>> GetVacations()
        {
            //return await _context.Vacations.ToListAsync();
            List<Vacation> list = _vacationService.GetAllVacations();
            return Ok(list);
        }

        // GET: api/Vacations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacation>> GetVacation(int id)
        {
            //var vacation = await _context.Vacations.FindAsync(id);
            var vacation = _vacationService.GetVacation(id);

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

            //_context.Entry(vacation).State = EntityState.Modified;
            _vacationService.StateVacation(vacation, EntityState.Modified);

            try
            {
                //await _context.SaveChangesAsync();
                _vacationService.SaveVacation();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_vacationService.VacationExists(id))
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
            //_context.Vacations.Add(vacation);
            //await _context.SaveChangesAsync();
            _vacationService.AddVacation(vacation);

            return CreatedAtAction("GetVacation", new { id = vacation.ID }, vacation);
        }

        // DELETE: api/Vacations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vacation>> DeleteVacation(int id)
        {
            //var vacation = await _context.Vacations.FindAsync(id);
            var vacation = _vacationService.DeleteVacation(id);
            if (vacation == null)
            {
                return NotFound();
            }

            //_context.Vacations.Remove(vacation);
            //await _context.SaveChangesAsync();

            return vacation;
        }
    }
}
