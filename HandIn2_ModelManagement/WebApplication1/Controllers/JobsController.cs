using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelManagement.Data;
using ModelManagement.Models;

namespace ModelManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobsController : Controller
    {
        private readonly ModelManagementDb _context;
        private readonly IMapper _mapper;

		public JobsController(ModelManagementDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


		// POST: api/Jobs
		[HttpPost]
		public async Task<ActionResult<Job>> PostModel(Job job)
		{
			if (job == null)
			{
				return Problem();
			}

			_context.Jobs.Add(job);

			await _context.SaveChangesAsync();

			return Created(job.JobId.ToString(), job);
		}
		

		// DELETE: api/Jobs
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteJob(long id)
		{
			var job = await _context.Jobs.FindAsync(id);
			if (job == null)
			{
				return NotFound();
			}

			_context.Jobs.Remove(job);
			await _context.SaveChangesAsync();

			return NoContent();
		}





	}
}
