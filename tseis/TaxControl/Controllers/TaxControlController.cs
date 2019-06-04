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

            var httpContent = JsonConvert.SerializeObject(trader);
            var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(httpContent));

            using (var response = await stockTraderClient.PostAsync($"api/v1/traders/{transaction.SellerID}", byteContent))
            {
                await response.Content.ReadAsStringAsync();
            }
            return Ok();
        }
    }
}