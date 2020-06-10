using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesDbsController : ControllerBase
    {
        private readonly EmpMgtContext _context;

        public EmployeesDbsController(EmpMgtContext context)
        {
            _context = context;
        }

        // GET: api/EmployeesDbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeesDb>>> GetEmployeesDb()
        {
            return await _context.EmployeesDb.ToListAsync();
        }

        // GET: api/EmployeesDbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeesDb>> GetEmployeesDb(int id)
        {
            var employeesDb = await _context.EmployeesDb.FindAsync(id);

            if (employeesDb == null)
            {
                return NotFound();
            }

            return employeesDb;
        }

        // PUT: api/EmployeesDbs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeesDb(int id, EmployeesDb employeesDb)
        {
            if (id != employeesDb.EmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(employeesDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesDbExists(id))
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

        // POST: api/EmployeesDbs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EmployeesDb>> PostEmployeesDb(EmployeesDb employeesDb)
        {
            _context.EmployeesDb.Add(employeesDb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeesDb", new { id = employeesDb.EmployeeID }, employeesDb);
        }

        // DELETE: api/EmployeesDbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeesDb>> DeleteEmployeesDb(int id)
        {
            var employeesDb = await _context.EmployeesDb.FindAsync(id);
            if (employeesDb == null)
            {
                return NotFound();
            }

            _context.EmployeesDb.Remove(employeesDb);
            await _context.SaveChangesAsync();

            return employeesDb;
        }

        private bool EmployeesDbExists(int id)
        {
            return _context.EmployeesDb.Any(e => e.EmployeeID == id);
        }
    }
}
