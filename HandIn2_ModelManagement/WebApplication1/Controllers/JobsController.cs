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
	        var jobs = await _context.Jobs.Include(j => j.Models).ToListAsync();

	        return Ok(_mapper.Map<IEnumerable<JobDto>>(jobs));
		}

        // GET: api/JobsController/5
		// Gets job with all expenses
		[HttpGet("expenses/{jobId}")]
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
        [HttpPut("updatejob/{jobId}")]
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
		[HttpPost("newjob")]
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
		[HttpDelete("{jobId}")]
		public async Task<IActionResult> DeleteJob(long jobId)
		{
			var job = await _context.Jobs.FindAsync(jobId);
			if (job == null)
			{
				return NotFound();
			}

			_context.Jobs.Remove(job);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		

		// PUT: api/jobController/model/5
		// Adds a model to a job
		[HttpPut("addModelToJob/{jobId}/{modelId}")]
		public async Task<ActionResult<NewModelForJobDto>> PutModel(long jobId, long modelId)
		{

			var job = await _context.Jobs.FindAsync(jobId);
			var newModel = await _context.Models.FindAsync(modelId);
			if (job == null || newModel == null)
			{
				return NotFound();
			}

			newModel.Jobs = new List<Job> { job };
			job.Models = new List<Model> { newModel };


			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!JobExists((jobId)))
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
		// Removes model from job
		[HttpDelete("removeModelFromJob/{jobId}/{modelId}")]
		public async Task<ActionResult> DeleteModel(long jobId, long modelId)
		{
			var job = await _context.Jobs.Include(d => d.Models).ToListAsync();
			if (job == null)
			{
				return NotFound();
			}

			var currentjob =job.Find(x => x.JobId == jobId);
			if (currentjob == null || currentjob.Models == null)
			{
				return NotFound();
			}

			currentjob.Models.RemoveAll(x => x.ModelId == modelId);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!JobExists((jobId)))
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


		// GET: api/JobsController/model/5
		// Gets all jobs for a given modelID
		[HttpGet("model/{modelId}")]
		public async Task<ActionResult> GetModel(long modelId)
		{
			var models = await _context.Models.Include(d => d.Jobs).ToListAsync();
			if (models == null)
			{
				return NotFound();
			}

			var currentModel = models.Find(x => x.ModelId == modelId);
			if(currentModel  == null || currentModel.Jobs == null)
			{
				return NotFound();
			}


			return Ok(_mapper.Map<IEnumerable<JobDtoReturn>>(currentModel.Jobs));
		}


		private bool JobExists(long id)
		{
			return _context.Jobs.Any(e => e.JobId == id);
		}




	}
}
