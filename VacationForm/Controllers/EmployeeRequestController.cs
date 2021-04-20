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
    public class EmployeeRequestController : ControllerBase
    {
        private readonly IEmployeeRequestService _employeeRequestService;

        public EmployeeRequestController(IEmployeeRequestService employeeRequestService)
        {
            this._employeeRequestService = employeeRequestService;
        }

        // GET: api/EmployeeRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeRequest>>> GetEmployeeRequests()
        {
            //return await _context.EmployeeRequests.ToListAsync();
            List<VacationRequestView> list = _employeeRequestService.GetAllEmployeeRequests();
            return Ok(list);
        }

        // GET: api/EmployeeRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeRequest>> GetEmployeeRequest(int id)
        {
            //var employeeRequest = await _context.EmployeeRequests.FindAsync(id);
            var employeeRequest = _employeeRequestService.GetEmployeeRequest(id);

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

            //_employeeRequestService.StateEmployeeRequest(employeeRequest, EntityState.Modified);
            try
            {
                EmployeeRequest er = new EmployeeRequest();
                er = _employeeRequestService.GetEmployeeRequest(id);
                int currval = er.Days;
                if (er != null)
                {
                    er.EmployeeID = employeeRequest.EmployeeID;
                    er.VacationID = employeeRequest.VacationID;
                    er.Days = employeeRequest.Days;
                }
                if (_employeeRequestService.employeeRequestValidationEdit(employeeRequest, currval))
                    return BadRequest();

                _employeeRequestService.SaveEmployeeRequest();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employeeRequest);
        }

        // POST: api/EmployeeRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeRequest>> PostEmployeeRequest(EmployeeRequest employeeRequest)
        {
            if (_employeeRequestService.employeeRequestValidationPost(employeeRequest))
                return BadRequest();

            _employeeRequestService.AddEmployeeRequest(employeeRequest);
            _employeeRequestService.SaveEmployeeRequest();

            return CreatedAtAction("GetEmployeeRequest", new { id = employeeRequest.ID }, employeeRequest);
        }

        // DELETE: api/EmployeeRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeRequest>> DeleteEmployeeRequest(int id)
        {
            //var employeeRequest = await _context.EmployeeRequests.FindAsync(id);
            var employeeRequest = _employeeRequestService.DeleteEmployeeRequest(id);
            if (employeeRequest == null)
            {
                return NotFound();
            }

            //_context.EmployeeRequests.Remove(employeeRequest);
            //await _context.SaveChangesAsync();
            _employeeRequestService.SaveEmployeeRequest();

            return employeeRequest;
        }
    }
}
