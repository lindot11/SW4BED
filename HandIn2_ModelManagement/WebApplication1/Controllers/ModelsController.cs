using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelManagement.Data;
using ModelManagement.Models;
using NuGet.Protocol.Core.Types;

namespace ModelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly ModelManagementDb _context;
        private readonly IMapper _mapper;

        public ModelsController(ModelManagementDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Models
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelDto>>> GetModels()
        {
	        var models = await _context.Models.ToListAsync();

	        return Ok(_mapper.Map<IEnumerable<ModelDto>>(models));
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model>> GetModel(long id)
        {
            var model = await _context.Models.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Entry(model)
                .Collection(m => m.Jobs)
                .Load();

			_context.Entry(model)
	            .Collection(m => m.Expenses)
	            .Load();

			return Ok(model);
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(long id, Model model)
        {
            if (id != model.ModelId)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
			{
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel(ModelDto modelDto)
        {
	        var model = _mapper.Map<Model>(modelDto);

            _context.Models.Add(model);

            await _context.SaveChangesAsync();

            return Created(model.ModelId.ToString(), model);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModel(long id)
        {
            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelExists(long id)
        {
            return _context.Models.Any(e => e.ModelId == id);
        }
    }
}
