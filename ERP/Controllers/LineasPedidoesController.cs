using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP.Data;
using ERP.Models;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineasPedidoesController : ControllerBase
    {
        private readonly ERPContext _context;

        public LineasPedidoesController(ERPContext context)
        {
            _context = context;
        }

        // GET: api/LineasPedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LineasPedido>>> GetLineasPedidos()
        {
            return await _context.LineasPedidos.ToListAsync();
        }

        // GET: api/LineasPedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LineasPedido>> GetLineasPedido(long id)
        {
            var lineasPedido = await _context.LineasPedidos.FindAsync(id);

            if (lineasPedido == null)
            {
                return NotFound();
            }

            return lineasPedido;
        }

        // PUT: api/LineasPedidoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineasPedido(long id, LineasPedido lineasPedido)
        {
            if (id != lineasPedido.IdLinea)
            {
                return BadRequest();
            }

            _context.Entry(lineasPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineasPedidoExists(id))
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

        // POST: api/LineasPedidoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LineasPedido>> PostLineasPedido(LineasPedido lineasPedido)
        {
            _context.LineasPedidos.Add(lineasPedido);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LineasPedidoExists(lineasPedido.IdLinea))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLineasPedido", new { id = lineasPedido.IdLinea }, lineasPedido);
        }

        // DELETE: api/LineasPedidoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LineasPedido>> DeleteLineasPedido(long id)
        {
            var lineasPedido = await _context.LineasPedidos.FindAsync(id);
            if (lineasPedido == null)
            {
                return NotFound();
            }

            _context.LineasPedidos.Remove(lineasPedido);
            await _context.SaveChangesAsync();

            return lineasPedido;
        }

        private bool LineasPedidoExists(long id)
        {
            return _context.LineasPedidos.Any(e => e.IdLinea == id);
        }
    }
}
