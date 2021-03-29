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
    public class EmployeeRequestController : ControllerBase
    {
        private readonly VacationContext _context;

        public EmployeeRequestController(VacationContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeRequest>>> GetEmployeeRequests()
        {
            return await _context.EmployeeRequests.ToListAsync();
        }

        // GET: api/EmployeeRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeRequest>> GetEmployeeRequest(int id)
        {
            var employeeRequest = await _context.EmployeeRequests.FindAsync(id);

            if (employeeRequest == null)
            {
                return NotFound();
            }

            return employeeRequest;
        }

        // PUT: api/EmployeeRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeRequest(int id, EmployeeRequest employeeRequest)
        {
            if (id != employeeRequest.ID)
            {
                return BadRequest();
            }

            _context.Entry(employeeRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeRequestExists(id))
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

        // POST: api/EmployeeRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeRequest>> PostEmployeeRequest(EmployeeRequest employeeRequest)
        {
            _context.EmployeeRequests.Add(employeeRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeRequest", new { id = employeeRequest.ID }, employeeRequest);
        }

        // DELETE: api/EmployeeRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeRequest>> DeleteEmployeeRequest(int id)
        {
            var employeeRequest = await _context.EmployeeRequests.FindAsync(id);
            if (employeeRequest == null)
            {
                return NotFound();
            }

            _context.EmployeeRequests.Remove(employeeRequest);
            await _context.SaveChangesAsync();

            return employeeRequest;
        }

        private bool EmployeeRequestExists(int id)
        {
            return _context.EmployeeRequests.Any(e => e.ID == id);
        }
    }
}
