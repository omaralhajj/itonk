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
        public const string GetById = "GetById";

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

            var httpContent = JsonConvert.SerializeObject(transaction);
            var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(httpContent));

            using (var response = await taxControlClient.PostAsync("api/v1/tax", byteContent))
            {
                await response.Content.ReadAsStringAsync();
            }

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Transaction), new { value = transaction.TransferValue }, transaction);
        }
    }
}