using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientsApi.Data;
using ClientsApi.Models;
using MassTransit;

namespace ClientsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamationsController : ControllerBase
    {
        private readonly ClientsApiContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public ReclamationsController(ClientsApiContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        // GET: api/Reclamations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reclamation>>> GetReclamation()
        {
            return await _context.Reclamation.Include(a => a.Client).ToListAsync();
        }

        // GET: api/Reclamations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reclamation>> GetReclamation(int id)
        {
            var reclamation = await _context.Reclamation.FindAsync(id);

            if (reclamation == null)
            {
                return NotFound();
            }

            return reclamation;
        }

        // PUT: api/Reclamations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReclamation(int id, Reclamation reclamation)
        {
            if (id != reclamation.ReclamationId)
            {
                return BadRequest();
            }

            _context.Entry(reclamation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReclamationExists(id))
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

        // POST: api/Reclamations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reclamation>> PostReclamation(Reclamation reclamation)
        {
            _context.Reclamation.Add(reclamation);
            await _context.SaveChangesAsync();

            await _publishEndpoint.Publish<Shared.Reclamation>(new Shared.Reclamation
            {
                ReclamationId = reclamation.ReclamationId,
                Description = reclamation.Description,
                Date= reclamation.Date,
                ClientId= reclamation.ClientId,
            });

            return CreatedAtAction("GetReclamation", new { id = reclamation.ReclamationId }, reclamation);
        }

        // DELETE: api/Reclamations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReclamation(int id)
        {
            var reclamation = await _context.Reclamation.FindAsync(id);
            if (reclamation == null)
            {
                return NotFound();
            }

            _context.Reclamation.Remove(reclamation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReclamationExists(int id)
        {
            return _context.Reclamation.Any(e => e.ReclamationId == id);
        }
    }
}
