using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Service.Services;

namespace VacationForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IVacationService _vacationService;

        public EmployeeController(IEmployeeService employeeService, IVacationService vacationService)
        {
            this._employeeService = employeeService;
            this._vacationService = vacationService;
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

            //_employeeService.StateEmployee(employee, EntityState.Modified);
            try
            {
                Employee emp = new Employee();
                emp = _employeeService.GetEmployee(id);
                if (emp != null)
                {
                    emp.FullName = employee.FullName;
                    emp.Email = employee.Email;
                    emp.BirthDate = employee.BirthDate;
                    emp.Gender = employee.Gender;

                }
                _employeeService.SaveEmployee();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            //if (_employeeservice.employeeexists(employee.fullname)) 
            //{
            //    var oldemployee = _employeeservice.getemployee(employee.fullname);
            //    _employeeservice.addemployee(employee);
            //    var vacation = _vacationservice.deletevacation(5);
            //    _employeeservice.saveemployee();
            //    return createdataction(nameof(getemployee), new { id = employee.id }, employee);
            //}

            /**email valiation is already handled in model**/
            if (_employeeService.EmployeeExists(employee.FullName))
            {
                return BadRequest();
            }

            _employeeService.AddEmployee(employee);
            _employeeService.SaveEmployee();

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
            _employeeService.SaveEmployee();

            return employee;
        }
    }
}
