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
        private readonly TransactionsControllerContext _context;
        private readonly HttpClient taxControlClient;

        public TransactionsController(TransactionsControllerContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            taxControlClient = clientFactory.CreateClient("taxControl");
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
            transaction.TimeStamp = DateTime.Now;

            var json = JsonConvert.SerializeObject(transaction);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            using (var response = await taxControlClient.PostAsync("api/v1/tax", httpContent))
            {
                await response.Content.ReadAsStringAsync();
            }

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Transaction), new { value = transaction.TransferValue }, transaction);
        }
    }
}