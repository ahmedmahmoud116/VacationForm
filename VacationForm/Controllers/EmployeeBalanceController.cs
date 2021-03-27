using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationForm.DBContexts;
using VacationForm.Models;

namespace VacationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBalanceController : ControllerBase
    {
        private readonly VacationContext _context;

        public EmployeeBalanceController(VacationContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeBalances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeBalance>>> GetEmployeeBalances()
        {
            return await _context.EmployeeBalances.ToListAsync();
        }

        // GET: api/EmployeeBalances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeBalance>> GetEmployeeBalance(int id)
        {
            var employeeBalance = await _context.EmployeeBalances.FindAsync(id);

            if (employeeBalance == null)
            {
                return NotFound();
            }

            return employeeBalance;
        }

        // PUT: api/EmployeeBalances/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeBalance(int id, EmployeeBalance employeeBalance)
        {
            if (id != employeeBalance.ID)
            {
                return BadRequest();
            }

            _context.Entry(employeeBalance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeBalanceExists(id))
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

        // POST: api/EmployeeBalances
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeBalance>> PostEmployeeBalance(EmployeeBalance employeeBalance)
        {

            _context.EmployeeBalances.Add(employeeBalance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeBalance", new { id = employeeBalance.ID }, employeeBalance);
        }

        // DELETE: api/EmployeeBalances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeBalance>> DeleteEmployeeBalance(int id)
        {
            var employeeBalance = await _context.EmployeeBalances.FindAsync(id);
            if (employeeBalance == null)
            {
                return NotFound();
            }

            _context.EmployeeBalances.Remove(employeeBalance);
            await _context.SaveChangesAsync();

            return employeeBalance;
        }

        private bool EmployeeBalanceExists(int id)
        {
            return _context.EmployeeBalances.Any(e => e.ID == id);
        }
    }
}
