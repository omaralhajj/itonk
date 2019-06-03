using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTransaction.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Newtonsoft.Json;
using StockTransaction.Context;
using Microsoft.EntityFrameworkCore;

namespace StockTransaction.Controllers
{
    [Route("api/v1")]
    public class TransactionsController : Controller
    {
        private readonly HttpClient httpClient;
        public const string GetById = "GetById";

        private readonly TransactionsControllerContext _context;

        public TransactionsController(HttpClient httpClient, TransactionsControllerContext context)
        {
            this.httpClient = httpClient;
            _context = context;
        }

        // GET api/v1/transactions
        [HttpGet("transactions")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        // POST api/v1/transactions
        [HttpPost("transactions")]
        public async Task<IActionResult> CreateTransaction([FromBody] [Required] Models.Transaction transaction)
        {
            // request tax payment here
            transaction.TimeStamp = DateTime.Now;
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Transaction), new { value = transaction.TransferValue }, transaction);
        }
    }
}