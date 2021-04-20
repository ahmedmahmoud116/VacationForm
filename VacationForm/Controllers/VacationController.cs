using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Service.Services;
using System;

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

            //_vacationService.StateEmployee(vacation, EntityState.Modified);
            try
            {
                Vacation vac = new Vacation();
                vac = _vacationService.GetVacation(id);
                if (vac != null)
                {
                    vac.Type = vacation.Type;
                    vac.Balance = vacation.Balance;
                }
                if (_vacationService.VacationValidationEdit(vac))
                    return BadRequest();

                _vacationService.SaveVacation();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(vacation);
        }

        // POST: api/Vacations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vacation>> PostVacation(Vacation vacation)
        {
            /**to validate if balance is positive**/
            if (_vacationService.VacationValidationPost(vacation))
                return BadRequest();

            _vacationService.AddVacation(vacation);
            _vacationService.SaveVacation();

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

            _vacationService.SaveVacation();
            //_context.Vacations.Remove(vacation);
            //await _context.SaveChangesAsync();

            return vacation;
        }
    }
}
