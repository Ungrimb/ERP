using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ERP.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq.Expressions;
using System.Threading;
using System.Data;
using Microsoft.Extensions.Configuration;
using ERP.Data;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController <T, TRepository> : ControllerBase
        where T : class, IEntity
        where TRepository : DataRepository<T>
    {
        private readonly TRepository repository;

        public GenericController (TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(long Id)
        {
            var entity = await repository.Get(Id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long Id, T entity)
        {
            if (Id != entity.Id)
            {
                return BadRequest();
            }
            await repository.Update(entity);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<T>> Post(T entity)
        {
            await repository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(long Id)
        {
            var entity = await repository.Delete(Id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
    }
}
