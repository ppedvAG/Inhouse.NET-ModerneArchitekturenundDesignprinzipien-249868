﻿using FancyPower3k.Business.Core.Contracts;
using FancyPower3k.DataAccess.Data;
using FancyPower3k.DomainModel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FancyPower3k.Web.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly FancyPowerDbContext _context;

        // Bessere Lösung
        //public EmployeesController(IEmployeeService employeeService)
        //{
            
        //}

        public EmployeesController(FancyPowerDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        // GET: api/Employees/5
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
