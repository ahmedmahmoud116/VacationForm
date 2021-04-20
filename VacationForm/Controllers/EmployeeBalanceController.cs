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
    public class EmployeeBalanceController : ControllerBase
    {
        private readonly IEmployeeBalanceService _employeeBalanceService;
        public EmployeeBalanceController(IEmployeeBalanceService employeeBalanceService)
        {
            this._employeeBalanceService = employeeBalanceService;
        }

        // GET: api/EmployeeBalances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeBalance>>> GetEmployeeBalances()
        {
            return Ok(_employeeBalanceService.GetAllEmployeeBalances());
            //return await _context.EmployeeBalances.ToListAsync();
        }



        // GET: api/EmployeeBalances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeBalance>> GetEmployeeBalance(int id)
        {
            //var employeeBalance = await _context.EmployeeBalances.FindAsync(id);
            var employeeBalance = _employeeBalanceService.GetEmployeeBalance(id);

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

            //_employeeBalanceService.StateEmployeeBalance(employeeBalance, EntityState.Modified);
            try
            {
                EmployeeBalance eb = new EmployeeBalance();
                eb = _employeeBalanceService.GetEmployeeBalance(id);
                if (eb != null)
                {
                    eb.EmployeeID = employeeBalance.EmployeeID;
                    eb.VacationID = employeeBalance.VacationID;
                    eb.Balance = employeeBalance.Balance;
                }
                /**to validate the input of put**/
                if (_employeeBalanceService.EmployeebalanceValidationEdit(eb))
                    return BadRequest();

                _employeeBalanceService.SaveEmployeeBalance();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employeeBalance);
        }

        [HttpPut]
        public async Task<IActionResult> PutEmployeeBalances(VacationView[] vacationViewArray)
        {
            try
            {
                _employeeBalanceService.UpdateEmployeeBalances(vacationViewArray);
                _employeeBalanceService.SaveEmployeeBalance();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(vacationViewArray);
        }

        // POST: api/EmployeeBalances
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeBalance>> PostEmployeeBalance(EmployeeBalance employeeBalance)
        {
            /**to validate employeebalance**/
            if (_employeeBalanceService.EmployeebalanceValidationPost(employeeBalance))
                return BadRequest();

            _employeeBalanceService.AddEmployeeBalance(employeeBalance);
            _employeeBalanceService.SaveEmployeeBalance();

            return CreatedAtAction("GetEmployeeBalance", new { id = employeeBalance.ID }, employeeBalance);
        }

        // DELETE: api/EmployeeBalances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeBalance>> DeleteEmployeeBalance(int id)
        {
            //var employeeBalance = await _context.EmployeeBalances.FindAsync(id);
            var employeeBalance = _employeeBalanceService.DeleteEmployeeBalance(id);

            if (employeeBalance == null)
            {
                return NotFound();
            }

            //_context.EmployeeBalances.Remove(employeeBalance);
            //await _context.SaveChangesAsync();
            _employeeBalanceService.SaveEmployeeBalance();

            return employeeBalance;
        }
    }
}
