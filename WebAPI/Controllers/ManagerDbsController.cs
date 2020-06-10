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
    public class ManagerDbsController : ControllerBase
    {
        private readonly EmpMgtContext _context;

        public ManagerDbsController(EmpMgtContext context)
        {
            _context = context;
        }

        // GET: api/ManagerDbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerDb>>> GetManagerDb()
        {
            return await _context.ManagerDb.ToListAsync();
        }

        // GET: api/ManagerDbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerDb>> GetManagerDb(int id)
        {
            var managerDb = await _context.ManagerDb.FindAsync(id);

            if (managerDb == null)
            {
                return NotFound();
            }

            return managerDb;
        }

        // PUT: api/ManagerDbs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagerDb(int id, ManagerDb managerDb)
        {
            if (id != managerDb.ManagerID)
            {
                return BadRequest();
            }

            _context.Entry(managerDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerDbExists(id))
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

        // POST: api/ManagerDbs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ManagerDb>> PostManagerDb(ManagerDb managerDb)
        {
            _context.ManagerDb.Add(managerDb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagerDb", new { id = managerDb.ManagerID }, managerDb);
        }

        // DELETE: api/ManagerDbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ManagerDb>> DeleteManagerDb(int id)
        {
            var managerDb = await _context.ManagerDb.FindAsync(id);
            if (managerDb == null)
            {
                return NotFound();
            }

            _context.ManagerDb.Remove(managerDb);
            await _context.SaveChangesAsync();

            return managerDb;
        }

        private bool ManagerDbExists(int id)
        {
            return _context.ManagerDb.Any(e => e.ManagerID == id);
        }
    }
}
