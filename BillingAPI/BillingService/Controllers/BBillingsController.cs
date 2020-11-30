using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillingService.Models;

namespace BillingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BBillingsController : ControllerBase
    {
        private readonly ModelContext _context;

        public BBillingsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/BBillings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BBilling>>> GetBBilling()
        {
            return await _context.BBilling.ToListAsync();
        }

        // GET: api/BBillings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BBilling>> GetBBilling(decimal id)
        {
            var bBilling = await _context.BBilling.FindAsync(id);

            if (bBilling == null)
            {
                return NotFound();
            }

            return bBilling;
        }

        // PUT: api/BBillings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBBilling(decimal id, BBilling bBilling)
        {
            if (id != bBilling.Id)
            {
                return BadRequest();
            }

            _context.Entry(bBilling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BBillingExists(id))
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

        // POST: api/BBillings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BBilling>> PostBBilling(BBilling bBilling)
        {
            _context.BBilling.Add(bBilling);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BBillingExists(bBilling.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBBilling", new { id = bBilling.Id }, bBilling);
        }

        // DELETE: api/BBillings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BBilling>> DeleteBBilling(decimal id)
        {
            var bBilling = await _context.BBilling.FindAsync(id);
            if (bBilling == null)
            {
                return NotFound();
            }

            _context.BBilling.Remove(bBilling);
            await _context.SaveChangesAsync();

            return bBilling;
        }

        private bool BBillingExists(decimal id)
        {
            return _context.BBilling.Any(e => e.Id == id);
        }
    }
}
