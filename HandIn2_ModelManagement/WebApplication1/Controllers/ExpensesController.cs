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
using ModelManagement.Profiles;

namespace ModelManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpensesController : Controller
    {
        private readonly ModelManagementDb _context;
        private readonly IMapper _mapper;

		public ExpensesController(ModelManagementDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

		

		// POST: api/Expenses
		[HttpPost]
		public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            if (expense == null)
            {
                return Problem();
            }
            
			_context.Expenses.Add(expense);

			await _context.SaveChangesAsync();

			
            return Created(expense.ExpenseId.ToString(), expense); 
        }

        private bool ExpenseExists(long id)
        {
          return _context.Expenses.Any(e => e.ExpenseId == id);
        }
    }
}
