using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERP.Data;
using ERP.Models;
using ERPAngular.Data;

namespace ERP.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LineasPedidosController : ControllerBase
    {
        private readonly ERPContext _context;
        private readonly IDataRepository<LineasPedido> _repo;

        public LineasPedidosController(ERPContext context, IDataRepository<LineasPedido> repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET: api/LineasPedidos
        [HttpGet]
        public IEnumerable<LineasPedido> GetEmpleados()
        {
            return _context.LineasPedidos.OrderByDescending(p => p.IdLinea);
        }

        // GET: api/LineasPedidos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLineasPedido([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lineasPedido = await _context.LineasPedidos.FindAsync(id);

            if (lineasPedido == null)
            {
                return NotFound();
            }

            return Ok(lineasPedido);
        }

        // PUT: api/LineasPedidos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLineasPedido([FromRoute] long id, [FromBody] LineasPedido lineasPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineasPedido.IdLinea)
            {
                return BadRequest();
            }

            _context.Entry(lineasPedido).State = EntityState.Modified;

            try
            {
                _repo.Update(lineasPedido);
                var save = await _repo.SaveAsync(lineasPedido);
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

        // POST: api/LineasPedidos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostLineasPedido([FromBody] LineasPedido lineasPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Add(lineasPedido);
            var save = await _repo.SaveAsync(lineasPedido);

            return CreatedAtAction("GetLineasPedido", new { id = lineasPedido.IdLinea }, lineasPedido);
        }

        // DELETE: api/LineasPedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLineasPedido([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lineasPedido = await _context.LineasPedidos.FindAsync(id);
            if (lineasPedido == null)
            {
                return NotFound();
            }

            _repo.Delete(lineasPedido);
            var save = await _repo.SaveAsync(lineasPedido);

            return Ok(lineasPedido);
        }

        private bool LineasPedidoExists(long id)
        {
            return _context.LineasPedidos.Any(e => e.IdLinea == id);
        }
    }
}
