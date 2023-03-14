using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
		[HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(long id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // PUT: api/JobsController/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{jobId}")]
        public async Task<IActionResult> PutJob(long jobId, JobUpdateDto newJob)
        {
	        try
	        {
		        var job = await _context.Jobs.FindAsync(jobId).ConfigureAwait(false);
		        if (job == null)
		        {
			        ModelState.AddModelError("jobId", "jobId not found");
			        return BadRequest(ModelState);
		        }
		        job.Comments = newJob.Comments;
		        job.Customer = newJob.Customer;
		        job.Days = newJob.Days;
		        job.Location = newJob.Location;
		        job.StartDate = newJob.StartDate;

		        await _context.SaveChangesAsync();
	        }
	        catch (DbUpdateConcurrencyException)
	        {
		        if (!JobExists(jobId))
		        {
			        ModelState.AddModelError("jobId", "jobId not found");
			        return BadRequest(ModelState);
		        }
		        else
		        {
			        throw;
		        }
	        }

	        return NoContent();
        }

		// POST: api/JobsController
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Job>> PostModel(NewJobDto jobdto)
		{
			var job = _mapper.Map<Job>(jobdto);

            if (job == null)
            {
                return Problem();
            }

            _context.Jobs.Add(job);

			await _context.SaveChangesAsync();

			return Created(job.JobId.ToString(), job);
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

		private bool JobExists(long id)
        {
            return _context.Jobs.Any(e => e.JobId == id);
        }


		// PUT: api/jobController/models/5
		[HttpPut("model/{id}")]
		public async Task<ActionResult<ModelDto>> PutModel(long id, ModelDto model)
		{

			var job = await _context.Jobs.FindAsync(id);
			if (job == null)
			{
				return Problem();
			}

			var newModel = _mapper.Map<Model>(model);

			if (newModel.Jobs == null)
			{
				newModel.Jobs = new List<Job>();
				newModel.Jobs.Add(job);
			}
			else
			{
				newModel.Jobs.Add(job);
			}


			if (job.Models == null)
			{
				job.Models = new List<Model>();
				job.Models.Add(newModel);
			}
			else
			{
				job.Models.Add(newModel);
			}

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



    }
}
