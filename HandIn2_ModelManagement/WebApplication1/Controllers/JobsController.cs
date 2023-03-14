using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using ModelManagement.Data;
using ModelManagement.Models;

namespace ModelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ModelManagementDb _context;
        private readonly IMapper _mapper;

        public JobsController(ModelManagementDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/JobsController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
        {
	        var jobs = await _context.Jobs.ToListAsync();

	        return Ok(_mapper.Map<IEnumerable<JobDto>>(jobs));
		}

        // GET: api/JobsController/5
		// Gets job with all expenses
		[HttpGet("{jobId}/Expenses")]
        public async Task<ActionResult<JobExpensesDto>> GetJob(long jobId)
        {
            var job = await _context.Jobs.FindAsync(jobId);

            if (job == null)
            {
                return NotFound();
            }
#pragma warning disable CS8603 // Possible null reference return.
			await _context.Entry(job)
	            .Collection(j => j.Expenses)
	            .LoadAsync();
#pragma warning restore CS8603 // Possible null reference return.

			var jobExpenses = _mapper.Map<JobExpensesDto>(job);

            return jobExpenses;
        }

        // PUT: api/JobsController/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{jobId}")]
        public async Task<IActionResult> PutJob(long jobId, JobUpdateDto updateJob)
        {
	        var job = await _context.Jobs.FindAsync(jobId);

	        if (job == null)
	        {
		        return NotFound();
	        }

			// Use Automapper to update the data:
			_mapper.Map(updateJob, job);
			_context.Entry(job).State = EntityState.Modified;

	        try
	        {
		        await _context.SaveChangesAsync();
	        }
	        catch (DbUpdateConcurrencyException)
	        {
		        if (!JobExists(jobId))
		        {
			        return NotFound();
		        }
		        else
		        {
			        throw;
		        }
	        }
			// Returns 204 - meaning no need to update page. 
			return NoContent();
        }

        // POST: api/JobsController
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Job>> PostJob(NewJobDto jobdto)
		{
			var job = _mapper.Map<Job>(jobdto);

            if (job == null)
            {
                return Problem();
            }

            _context.Jobs.Add(job);

			await _context.SaveChangesAsync();

			//return NoContent();
			var createdJob = _mapper.Map<JobDtoReturn>(job);
			return CreatedAtAction("PostJob", new { id = job.JobId }, createdJob);
			//return Created(job.JobId.ToString(), job);
		}

		// DELETE: api/JobsController/5
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

		

		// PUT: api/jobController/model/5
		[HttpPut("model/{id}")]
		public async Task<ActionResult<NewModelForJobDto>> PutModel(long id, NewModelForJobDto model)
		{

			var job = await _context.Jobs.FindAsync(id);
			if (job == null)
			{
				return Problem();
			}

			var newModel = _mapper.Map<Model>(model);

			
			newModel.Jobs = new List<Job> { job };
			job.Models = new List<Model> { newModel };


			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!JobExists((id)))
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



		// DELETE: api/JobsController/model/5
		[HttpDelete("model/{id}")]
		public async Task<ActionResult> DeleteModel(long id)
		{
			var job = await _context.Jobs.Include(d => d.Models).ToListAsync();
			if (job == null)
			{
				return NotFound();
			}

			var currentjob =job.Find(x => x.JobId == id);
			if (currentjob == null || currentjob.Models == null)
			{
				return NotFound();
			}

			currentjob.Models.RemoveAll(x => x.ModelId == 5);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!JobExists((id)))
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



		private bool JobExists(long id)
		{
			return _context.Jobs.Any(e => e.JobId == id);
		}




	}
}
