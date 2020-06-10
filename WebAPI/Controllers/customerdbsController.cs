
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
    public class customerdbsController : ControllerBase
    {
        private readonly EmpMgtContext _context;

        public customerdbsController(EmpMgtContext context)
        {
            _context = context;
        }

        // GET: api/customerdbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<customerdb>>> Getcustomerdb()
        {
            return await _context.customerdb.ToListAsync();
        }

        // GET: api/customerdbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<customerdb>> Getcustomerdb(int id)
        {
            var customerdb = await _context.customerdb.FindAsync(id);

            if (customerdb == null)
            {
                return NotFound();
            }

            return customerdb;
        }

        // PUT: api/customerdbs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcustomerdb(int id, customerdb customerdb)
        {
            if (id != customerdb.cust_id)
            {
                return BadRequest();
            }

            _context.Entry(customerdb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customerdbExists(id))
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

        // POST: api/customerdbs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<customerdb>> Postcustomerdb(customerdb customerdb)
        {
            _context.customerdb.Add(customerdb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcustomerdb", new { id = customerdb.cust_id }, customerdb);
        }

        // DELETE: api/customerdbs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<customerdb>> Deletecustomerdb(int id)
        {
            var customerdb = await _context.customerdb.FindAsync(id);
            if (customerdb == null)
            {
                return NotFound();
            }

            _context.customerdb.Remove(customerdb);
            await _context.SaveChangesAsync();

            return customerdb;
        }

        private bool customerdbExists(int id)
        {
            return _context.customerdb.Any(e => e.cust_id == id);
        }
    }
}
