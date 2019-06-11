using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxControl.Models;
using Newtonsoft.Json;

namespace TaxControl.Controllers
{
    [Route("api/v1")]
    public class TaxControlController : Controller
    {
        private readonly HttpClient stockTraderClient;

        public TaxControlController(IHttpClientFactory clientFactory)
        {
            stockTraderClient = clientFactory.CreateClient("stockTraderControl");
        }

        [HttpPost("tax")]
        public async Task<IActionResult> DepositTaxPayment([FromBody] Transaction transaction)
        {
            Trader trader = new Trader();
            var tax = transaction.TransferValue * (decimal)0.01;
            trader.Credit = trader.Credit - tax;

            var json = JsonConvert.SerializeObject(trader);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            using (var response = await stockTraderClient.PutAsync($"api/v1/traders/{transaction.SellerID}", httpContent))
            {
                await response.Content.ReadAsStringAsync();
            }
            return NoContent();
        }
    }
}