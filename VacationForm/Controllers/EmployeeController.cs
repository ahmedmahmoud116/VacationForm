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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            //List<Employee> list = await Task.Run(() => employeeService.GetAllEmployees());
            List<Employee> list = _employeeService.GetAllEmployees();
            return Ok(list);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            //var employee = await _context.Employees.FindAsync(id);
            var employee = _employeeService.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }

            //_context.Entry(employee).State = EntityState.Modified;
            _employeeService.StateEmployee(employee, EntityState.Modified);

            try
            {
                //await _context.SaveChangesAsync();
                _employeeService.SaveEmployee();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_employeeService.EmployeeExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            //_context.Employees.Add(employee);
            //await _context.SaveChangesAsync();
            _employeeService.AddEmployee(employee);

            //return CreatedAtAction("GetEmployee", new { id = employee.ID }, employee); 
            //The CreatedAtAction method: Returns an HTTP 201 status code if successful.
            //HTTP 201 is the standard response for an HTTP POST method that creates a new resource on the server.
            //reference GetEmployee action to create the location url
            //the C# nameof keyword is used to avoid hard-coding the action name in the CreatedAtAction call
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.ID }, employee); //reference GetEmployee action to create 
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            //var employee = await _context.Employees.FindAsync(id);
            var employee = _employeeService.DeleteEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            //_context.Employees.Remove(employee);
            //await _context.SaveChangesAsync();

            return employee;
        }
    }
}
