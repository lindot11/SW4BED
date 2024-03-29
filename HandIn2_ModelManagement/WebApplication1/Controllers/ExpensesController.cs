﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using ModelManagement.Data;
using ModelManagement.Hubs;
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
        private readonly IHubContext<MessageHub, IMessage> _hubContext;

        public ExpensesController(ModelManagementDb context, IMapper mapper, IHubContext<MessageHub, IMessage> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        // POST: api/Expenses
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(NewExpense newExpense)
        {
            if (newExpense == null)
            {
                return Problem();
            }

            var expense = _mapper.Map<Expense>(newExpense);

            _context.Expenses.Add(expense);

            await _context.SaveChangesAsync();

            string str = $"{expense.Date}: {expense.amount} DKK was spent on: {expense.Text}";

            await _hubContext.Clients.All.NewExpense(str);

			return Created(expense.ExpenseId.ToString(), expense);
        }

        private bool ExpenseExists(long id)
        {
            return _context.Expenses.Any(e => e.ExpenseId == id);
        }
    }
}


