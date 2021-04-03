using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.DBContexts;
using Model.Models;
using Service.Services;
using Service.Serv;

namespace VacationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBalanceController : ControllerBase
    {
        private readonly IEmployeeBalanceService _employeeBalanceService;
        private readonly VacationContext _context;
        public EmployeeBalanceController(IEmployeeBalanceService employeeBalanceService, VacationContext context)
        {
            this._employeeBalanceService = employeeBalanceService;
            this._context = context;
        }

        // GET: api/EmployeeBalances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeBalance>>> GetEmployeeBalances()
        {
            var query = from e in _context.Employees
                        join eb in _context.EmployeeBalances on e.ID equals eb.EmployeeID
                        join v in _context.Vacations on eb.VacationID equals v.ID into group2
                        from g2 in group2.DefaultIfEmpty()
                        join er in _context.EmployeeRequests on new { eb.EmployeeID, eb.VacationID }
                                                             equals new { er.EmployeeID, er.VacationID } into group3
                        from g3 in group3.DefaultIfEmpty()
                        orderby e.FullName
                        select new VacationView { FullName = e.FullName, Type = g2.Type, Balance = eb.Balance, Used = g3.Days };

            List<VacationView> employeevacations = query.ToList();
            employeevacations = employeevacations.GroupBy(v => new
            {
                v.Type,
                v.FullName
            })
                .Select(g => new VacationView()
            {
                Type = g.Key.Type,
                FullName = g.Key.FullName,
                Balance = g.FirstOrDefault().Balance,
                Used = g.Sum(u => u.Used)
            }).ToList();

            return Ok(employeevacations);
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

            //_context.Entry(employeeBalance).State = EntityState.Modified;
            _employeeBalanceService.StateEmployeeBalance(employeeBalance, EntityState.Modified);

            try
            {
                //await _context.SaveChangesAsync();
                _employeeBalanceService.SaveEmployeeBalance();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_employeeBalanceService.EmployeeBalanceExists(id))
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

            //_context.EmployeeBalances.Add(employeeBalance);
            //await _context.SaveChangesAsync();
            
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
