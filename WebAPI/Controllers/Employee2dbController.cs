using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee2dbController : ControllerBase
    {
        private readonly EmpMgtContext _context;

        public Employee2dbController(EmpMgtContext context)
        {
            _context = context;
        }

        // GET: api/Employee2db
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee2db>>> GetEmployees2Db()
        {
            return await _context.Employees2Db.ToListAsync();
        }

        // GET: api/Employee2db/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee2db>> GetEmployee2db(int id)
        {
            var employee2db = await _context.Employees2Db.FindAsync(id);

            if (employee2db == null)
            {
                return NotFound();
            }

            return employee2db;
        }

        // PUT: api/Employee2db/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee2db(int id, Employee2db employee2db)
        {
            if (id != employee2db.id)
            {
                return BadRequest();
            }

            _context.Entry(employee2db).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee2dbExists(id))
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

        // POST: api/Employee2db
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Employee2db>> PostEmployee2db(Employee2db employee2db)
        {
            _context.Employees2Db.Add(employee2db);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee2db", new { id = employee2db.id }, employee2db);
        }

        // DELETE: api/Employee2db/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee2db>> DeleteEmployee2db(int id)
        {
            var employee2db = await _context.Employees2Db.FindAsync(id);
            if (employee2db == null)
            {
                return NotFound();
            }

            _context.Employees2Db.Remove(employee2db);
            await _context.SaveChangesAsync();

            return employee2db;
        }

        private bool Employee2dbExists(int id)
        {
            return _context.Employees2Db.Any(e => e.id == id);
        }
    }
}
